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
    public interface IFloorService
    {
        List<DescriptionViewModel> Get(Guid? id);
        Guid Add(DescriptionModel model);
        Guid Update(Guid id, DescriptionModel model);
        Guid Delete(Guid id);
    }
    public class FloorService : IFloorService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public FloorService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DescriptionViewModel> Get(Guid? id)
        {
            var floors = _dbContext.Floors.Where(f => id == null || f.Id == id).Where(f => f.IsDeleted == false).OrderBy(f => f.Description).ToList();
            return _mapper.Map<List<DescriptionViewModel>>(floors);
        }

        public Guid Add(DescriptionModel model)
        {
            var newFloor = new Floor() { Description = model.Description };

            _dbContext.Add(newFloor);
            _dbContext.SaveChanges();

            return newFloor.Id;
        }

        public Guid Update(Guid id, DescriptionModel model)
        {
            var data = _dbContext.Floors.FirstOrDefault(f => f.Id == id);
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
            var data = _dbContext.Floors.FirstOrDefault(f => f.Id == id);
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
