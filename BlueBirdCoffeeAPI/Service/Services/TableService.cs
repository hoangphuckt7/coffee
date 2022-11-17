using AutoMapper;
using Data.AppException;
using Data.Cache;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        Task<Guid> ChangeTable(Guid oldTableId, Guid newTableId);
    }
    public class TableService : ITableService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITableHub _tableHub;

        public TableService(AppDbContext dbContext, IMapper mapper, UserManager<User> userManager, ITableHub tableHub)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
            _tableHub = tableHub;
        }

        public List<TableViewModel> Get(Guid? id, Guid? floorId)
        {
            var tables = _dbContext.Tables
                .Where(t => id == null || t.Id == id)
                .Where(f => f.IsDeleted == false)
                .Where(f => floorId == null || f.FloorId == floorId)
                .OrderBy(f => f.Description)
                .ToList();

            try
            {
                tables = tables.OrderBy(f => int.Parse(f.Description)).ToList();
            }
            catch (Exception) { }

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

        public async Task<Guid> ChangeTable(Guid oldTableId, Guid newTableId)
        {
            var tableOld = _dbContext.Tables.FirstOrDefault(x => x.Id == oldTableId);
            if (tableOld == null)
            {
                throw new AppException("Mã số bàn cũ không hợp lệ!");
            }

            var tableNew = _dbContext.Tables.FirstOrDefault(x => x.Id == newTableId);
            if (tableNew == null)
            {
                throw new AppException("Mã số bàn mới không hợp lệ!");
            }

            var lstOrderByTable = _dbContext.Orders.Where(x => !x.IsCheckout && !x.IsCompleted && !x.IsDeleted && !x.IsMissing && x.TableId == oldTableId).ToList();
            if (!lstOrderByTable.Any())
            {
                throw new AppException($"Bàn {tableOld.Description} không có order nào!");
            }

            foreach (var order in lstOrderByTable)
            {
                order.TableId = newTableId;
                order.DateUpdated = DateTime.UtcNow.AddHours(7);
            }

            tableNew.CurrentOrder += tableOld.CurrentOrder;
            tableOld.CurrentOrder = 0;

            _dbContext.UpdateRange(lstOrderByTable);
            _dbContext.SaveChanges();

            try
            {
                var cashers = await _userManager.GetUsersInRoleAsync(SystemRoles.CASHIER);

                foreach (var casher in cashers)
                {
                    await _tableHub.ChangeStatus(_mapper.Map<TableViewModel>(tableNew), casher.Id);
                    await _tableHub.ChangeStatus(_mapper.Map<TableViewModel>(tableOld), casher.Id);
                }
            }
            //Ignore errors
            catch (Exception) { }

            return newTableId;
        }
    }
}
