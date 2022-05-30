﻿using AutoMapper;
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
    public interface ITableService
    {
        List<TableViewModel> Get(Guid? id, Guid? floorId);
        Guid Add(TableAddModel model);
        int UpdateOrAdd(List<TableUpdateModel> models);
        int Delete(List<Guid> ids);
    }
    public class TableService : ITableService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TableService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TableViewModel> Get(Guid? id, Guid? floorId)
        {
            var tables = _dbContext.Tables
                .Where(t => id == null || t.Id == id)
                .Where(f => f.IsDeleted == false)
                .Where(f => floorId == null || f.FloorId == floorId)
                //.OrderByDescending(f => f.Description)
                .ToList();
            return _mapper.Map<List<TableViewModel>>(tables);
        }

        public Guid Add(TableAddModel model)
        {
            var newTable = _mapper.Map<Table>(model);

            _dbContext.Add(newTable);
            _dbContext.SaveChanges();

            return newTable.Id;
        }

        public int UpdateOrAdd(List<TableUpdateModel> models)
        {
            foreach (var model in models)
            {
                var table = _dbContext.Tables.FirstOrDefault(t => t.Id == model.Id);
                if (table == null)
                {
                    var newTable = _mapper.Map<Table>(model);
                    _dbContext.Add(newTable);
                }
                else
                {
                    table.Description = model.Description;
                    table.Position = model.Position;
                    table.Size = model.Size;
                    table.Shape = model.Shape;
                    table.FloorId = model.FloorId;
                    table.DateUpdated = DateTime.UtcNow.AddHours(7);
                    table.Rotation = model.Rotation;

                    _dbContext.Update(table);
                }
            }

            _dbContext.SaveChanges();

            return models.Count;
        }

        public int Delete(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var data = _dbContext.Tables.FirstOrDefault(f => f.Id == id);
                if (data == null)
                {
                    throw new AppException("Invalid Id");
                }

                data.DateUpdated = DateTime.UtcNow.AddHours(7);
                data.IsDeleted = true;

                _dbContext.Update(data);
            }

            _dbContext.SaveChanges();

            return ids.Count;
        }
    }
}
