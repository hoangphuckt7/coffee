using AutoMapper;
using Data.AppException;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface ICategoryService
    {
        List<DescriptionViewModel> Get(Guid? id);
        Guid Add(DescriptionModel model);
        Guid Update(Guid id, DescriptionModel model);
        Guid Delete(Guid id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DescriptionViewModel> Get(Guid? id)
        {
            var floors = _dbContext.Categories.Where(f => id == null || f.Id == id).Where(f => f.IsDeleted == false).ToList();
            return _mapper.Map<List<DescriptionViewModel>>(floors);
        }

        public Guid Add(DescriptionModel model)
        {
            var newCategory = new Category() { Description = model.Description };

            _dbContext.Add(newCategory);
            _dbContext.SaveChanges();

            return newCategory.Id;
        }

        public Guid Update(Guid id, DescriptionModel model)
        {
            var data = _dbContext.Categories.FirstOrDefault(f => f.Id == id);
            if (data == null)
            {
                throw new AppException("Invalid Id");
            }

            data.Description = model.Description;
            data.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(data);
            _dbContext.SaveChanges();

            return data.Id;
        }

        public Guid Delete(Guid id)
        {
            var data = _dbContext.Categories.FirstOrDefault(f => f.Id == id);
            if (data == null)
            {
                throw new AppException("Invalid Id");
            }

            data.DateUpdated = DateTime.UtcNow.AddHours(7);
            data.IsDeleted = true;

            _dbContext.Update(data);
            _dbContext.SaveChanges();

            return data.Id;
        }
    }
}
