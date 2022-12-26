using AutoMapper;
using Data.AppException;
using Data.DataAccessLayer;
using Data.Entities;
using Data.Enums;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        Guid Update(Guid id, ItemUpdateModel model);
        Guid Delete(Guid id);
        List<ItemStatisticModel> Statistic(DateTime? date, DateTime? fromDate, DateTime? toDate);
        FileViewModel GetItemImage(Guid id);
        Guid AddImages(Guid itemId, List<IFormFile> images);
        Guid RemoveImage(Guid imageId);
        List<Guid> DefaultItems();
        Guid RemoveDefault(Guid itemId);
        Guid SetDefault(Guid itemId);
    }
    public class ItemService : IItemService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISettingService _settingService;

        public ItemService(AppDbContext dbContext, IMapper mapper, ISettingService settingService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _settingService = settingService;
        }

        public List<ItemViewModel> Search(Guid? id, string? name, Guid? categoryId)
        {
            var data = _dbContext.Items
                .Where(x => categoryId == null || x.CategoryId == categoryId)
                .Where(x => id == null || x.Id == id)
                .Where(x => x.IsDeleted == false)
                .ToList();

            data = data.Where(f => string.IsNullOrEmpty(name) || RemoveVNChar(f.Name).ToLower().Contains(name.ToLower()) || f.Name.ToLower().Contains(name.ToLower())).ToList();

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
        private static readonly string[] VietNamChar = new string[]{
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"};
        public static string RemoveVNChar(string str)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
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
        public Guid Update(Guid id, ItemUpdateModel model)
        {
            var data = _dbContext.Items.FirstOrDefault(f => f.Id == id);
            if (data == null) throw new AppException("Invalid id");

            data.Description = model.Description;
            data.Name = model.Name;
            data.Price = model.Price;
            data.CategoryId = model.CategoryId;

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
        public List<ItemStatisticModel> Statistic(DateTime? date, DateTime? fromDate, DateTime? toDate)
        {
            var items = _dbContext.Items
                .Where(f => f.IsDeleted == false)
                .ToList();

            var ordersQuerry = _dbContext.Orders.Where(f => f.IsDeleted == false & f.IsCheckout == true)
                .Where(f => date == null || date.Value.Date == f.DateCreated.Date)
                .Where(f => (fromDate == null || toDate == null) || (f.DateCreated.Date >= fromDate.Value.Date && f.DateCreated.Date <= toDate.Value.Date));

            var itemImages = _dbContext.ItemImages.Where(f => f.IsDeleted == false).ToList();

            var result = _mapper.Map<List<ItemStatisticModel>>(items);

            foreach (var item in result)
            {
                item.Selled = ordersQuerry.Sum(f => f.OrderDetails.Where(o => o.ItemId == item.Id).Sum(o => o.FinalQuantity));
                item.Total = ordersQuerry.Sum(f => f.OrderDetails.Where(o => o.ItemId == item.Id).Sum(o => o.FinalQuantity * o.Price));

                item.Images = itemImages
                    .Where(f => f.ItemId == item.Id)
                    .Select(s => s.Id).ToList();
            }

            result = result.OrderByDescending(f => f.Selled).ToList();
            return result;
        }

        public List<Guid> DefaultItems()
        {
            var orderDefaults = _settingService.GetKeys(MandatorySettings.ORDER_DEFAULT.ToString());
            if (orderDefaults == null || orderDefaults.Count == 0)
            {
                throw new AppException("Lỗi khi khởi chạy ứng dụng");
            }
            var orderDefault = orderDefaults.First();

            return JsonConvert.DeserializeObject<List<Guid>>(orderDefault.Value);
        }
        public Guid RemoveDefault(Guid itemId)
        {
            var orderDefaults = _settingService.GetKeys(MandatorySettings.ORDER_DEFAULT.ToString());
            if (orderDefaults == null || orderDefaults.Count == 0)
            {
                throw new AppException("Lỗi khi khởi chạy ứng dụng");
            }
            var orderDefault = orderDefaults.First();
            var currentData = JsonConvert.DeserializeObject<List<Guid>>(orderDefault.Value);

            if (currentData.Contains(itemId))
            {
                currentData.Remove(itemId);
                _settingService.UpdateSetting(MandatorySettings.ORDER_DEFAULT.ToString(), new StringModel() { Description = JsonConvert.SerializeObject(currentData) });
            }

            return itemId;
        }
        public Guid SetDefault(Guid itemId)
        {
            var currentItem = _dbContext.Items.Any(f => f.Id == itemId);
            if (!currentItem)
            {
                throw new AppException("Invalid item");
            }
            var orderDefaults = _settingService.GetKeys(MandatorySettings.ORDER_DEFAULT.ToString());
            if (orderDefaults == null || orderDefaults.Count == 0)
            {
                throw new AppException("Lỗi khi khởi chạy ứng dụng");
            }
            var orderDefault = orderDefaults.First();
            var currentData = JsonConvert.DeserializeObject<List<Guid>>(orderDefault.Value);

            if (!currentData.Contains(itemId))
            {
                currentData.Add(itemId);
                _settingService.UpdateSetting(MandatorySettings.ORDER_DEFAULT.ToString(), new StringModel() { Description = JsonConvert.SerializeObject(currentData) });
            }

            return itemId;
        }
    }
}
