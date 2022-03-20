using AutoMapper;
using Data.AppException;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IItemService
    {
        Guid Add(ItemAddModel model);
        List<ItemViewModel> Search(Guid? id, string? name, Guid? categoryId);
        Guid Update(Guid id, ItemAddModel model);
        Guid Delete(Guid id);

        FileViewModel GetItemImage(Guid id);
        Guid AddImages(Guid itemId, List<IFormFile> images);
        Guid RemoveImage(Guid imageId);
    }
    public class ItemService : IItemService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ItemService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ItemViewModel> Search(Guid? id, string? name, Guid? categoryId)
        {
            var data = _dbContext.Items
                .Where(x => categoryId == null || x.CategoryId == categoryId)
                .Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name))
                .Where(x => id == null || x.Id == id)
                .Where(x => x.IsDeleted == false)
                .ToList();
            var result = _mapper.Map<List<ItemViewModel>>(data);

            foreach (var item in result)
            {
                item.Images = _dbContext.ItemImages
                    .Where(f => f.ItemId == item.Id)
                    .Where(f => f.IsDeleted == false)
                    .Select(s => s.Id).ToList();
            }

            return result;
        }
        public Guid Add(ItemAddModel model)
        {
            var data = _mapper.Map<ItemAddModel, Item>(model);

            _dbContext.Add(data);

            if (model.Images != null)
            {
                foreach (var item in model.Images)
                {
                    var itemImage = new ItemImage()
                    {
                        ItemId = data.Id,
                        Image = ImageToBytes(item)
                    };

                    _dbContext.Add(itemImage);
                }
            }

            _dbContext.SaveChanges();
            return data.Id;
        }
        public Guid Update(Guid id, ItemAddModel model)
        {
            var data = _dbContext.Items.FirstOrDefault(f => f.Id == id);
            if (data == null) throw new AppException("Invalid id");

            data = _mapper.Map<Item>(model);

            if (model.Images != null)
            {
                foreach (var item in model.Images)
                {
                    var itemImage = new ItemImage()
                    {
                        ItemId = data.Id,
                        Image = ImageToBytes(item)
                    };

                    _dbContext.Add(itemImage);
                }
            }

            _dbContext.Update(data);
            _dbContext.SaveChanges();

            return data.Id;
        }
        public Guid Delete(Guid id)
        {
            var data = _dbContext.Items.FirstOrDefault(f => f.Id == id);
            if (data == null) throw new AppException("Invalid id");

            data.IsDeleted = true;
            data.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(data);
            _dbContext.SaveChanges();

            return data.Id;
        }

        public FileViewModel GetItemImage(Guid id)
        {
            var result = new FileViewModel();
            var image = _dbContext.ItemImages.FirstOrDefault(f => f.Id == id);
            if (image == null) throw new AppException("Invalid id");

            result.Id = image.Id;
            result.Data = image.Image;
            return result;
        }
        public Guid AddImages(Guid itemId, List<IFormFile> images)
        {
            foreach (var item in images)
            {
                var itemImage = new ItemImage()
                {
                    ItemId = itemId,
                    Image = ImageToBytes(item)
                };
                _dbContext.Add(itemImage);
            }

            _dbContext.SaveChanges();

            return itemId;
        }
        public Guid RemoveImage(Guid imageId)
        {
            var image = _dbContext.ItemImages.FirstOrDefault(f => f.Id == imageId);
            if (image == null) throw new AppException("Invalid Id");

            image.IsDeleted = true;
            image.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(image);
            _dbContext.SaveChanges();

            return image.Id;
        }

        private byte[]? ImageToBytes(IFormFile image)
        {
            if (image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    return ms.ToArray();
                    //string s = Convert.ToBase64String(fileBytes);
                }
            }
            return null;
        }
    }
}
