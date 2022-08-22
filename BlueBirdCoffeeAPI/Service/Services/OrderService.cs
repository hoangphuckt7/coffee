using AutoMapper;
using Data.AppException;
using Data.Cache;
using Data.DataAccessLayer;
using Data.Entities;
using Data.Enums;
using Data.ViewModels;
using Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrder(string employeeId, OrderCreateModel models);
        List<OrderViewModel> GetByTable(Guid tableId);
        List<OrderDetailViewModel> TodateMissingItem();
        Guid SetMissingOrder(SetMissingOrders model, string emp);
        void SetMissingItem(SetMissingItemModel model);
        List<OrderViewModel> GetByIds(List<Guid> ids);
    }
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly INotificationHub _notificationHub;
        private readonly UserManager<User> _userManager;
        private readonly ITableHub _tableHub;

        public OrderService(AppDbContext dbContext, IMapper mapper, INotificationHub notificationHub, UserManager<User> userManager, ITableHub tableHub)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _notificationHub = notificationHub;
            _userManager = userManager;
            _tableHub = tableHub;
        }

        public async Task<Guid> CreateOrder(string employeeId, OrderCreateModel models)
        {
            Table? table = null;
            var transaction = _dbContext.Database.BeginTransaction();

            var order = new Order()
            {
                TableId = models.TableId,
                //EmployeeId = employeeId
            };

            try
            {
                _dbContext.Add(order);

                foreach (var item in models.OrderDetail)
                {
                    var itemDetail = _dbContext.Items.FirstOrDefault(f => f.Id == item.ItemId);

                    var newOrderDetail = new OrderDetail()
                    {
                        Description = itemDetail.Description,
                        ItemId = itemDetail.Id,
                        OrderId = order.Id,
                        Price = itemDetail.Price,
                        Quantity = item.Quantity
                    };

                    _dbContext.Add(newOrderDetail);
                }

                _dbContext.SaveChanges();

                if (models.TableId != null)
                {
                    table = _dbContext.Tables.FirstOrDefault(f => f.Id == order.TableId);
                    if (table == null) throw new AppException("Mã số bàn không hợp lệ!");
                    table.CurrentOrder += 1;
                    _dbContext.Tables.Update(table);
                }

                _dbContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }

            var notify = _mapper.Map<OrderViewModel>(order);
            notify.Id = order.Id;

            var orderReceivers = CacheSetting.CacheSettings.FirstOrDefault(f => f.Key == MandatorySettings.ORDER_RECEIVER.ToString());

            var roles = JsonConvert.DeserializeObject<List<string>>(orderReceivers.Value);

            foreach (var role in roles)
            {
                var users = await _userManager.GetUsersInRoleAsync(role);
                foreach (var user in users)
                {
                    await _notificationHub.NewTaskNotification(notify, user.Id);
                }
            }

            if (table != null)
            {
                var cashers = await _userManager.GetUsersInRoleAsync(SystemRoles.CASHER);
                foreach (var casher in cashers)
                {
                    await _tableHub.ChangeStatus(_mapper.Map<TableViewModel>(table), casher.Id);
                }
            }

            return order.Id;
        }
        public List<OrderViewModel> GetByTable(Guid tableId)
        {
            var orders = _dbContext.Orders
                //.Include(f => f.OrderDetails)
                .Where(o => o.TableId == tableId && o.IsDeleted == false && o.IsCheckout == false)
                .ToList();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public List<OrderViewModel> GetByIds(List<Guid> ids)
        {
            var orders = _dbContext.Orders
                //.Include(f => f.OrderDetails)
                .Where(o => ids.Contains(o.Id) && o.IsDeleted == false)
                .ToList();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public Guid SetMissingOrder(SetMissingOrders model, string emp)
        {
            var order = _dbContext.Orders.FirstOrDefault(f => model.OrderIds.Contains(f.Id));
            if (order == null) throw new AppException("Invalid order id");

            order.IsMissing = true;
            order.EmployeeId = emp;

            order.DateUpdated = DateTime.Now;

            _dbContext.Update(order);
            _dbContext.SaveChanges();

            return order.Id;
        }

        public void SetMissingItem(SetMissingItemModel model)
        {
            //var orders = _dbContext.Orders.Include(o => o.OrderDetails).Where(f => model.MissingItems.Select(s => s.OrderId).Contains(f.Id)).ToList();

            //foreach (var order in orders)
            //{
            //    var itemIds = model.MissingItems.Where(s => s.OrderId == order.Id).ToList().Select(s => s.ItemId);

            //    if (order.OrderDetails != null)
            //    {
            //        var items = order.OrderDetails.Where(s => itemIds.Contains(s.ItemId)).ToList();

            //        foreach (var item in items)
            //        {
            //            //item.IsMissing = true;
            //            item.DateUpdated = DateTime.Now;

            //            _dbContext.Update(item);
            //        }
            //    }
            //}

            //_dbContext.SaveChanges();
            throw new Exception();
        }

        public List<OrderDetailViewModel> TodateMissingItem()
        {
            //var now = DateTime.Now;
            //var orders = _dbContext.Orders.Include(s => s.OrderDetails).Where(s => s.IsMissing == true && s.DateUpdated.Year == DateTime.Now.Year && s.DateUpdated.Month == DateTime.Now.Month && s.DateUpdated.Day == DateTime.Now.Day).ToList();

            //var orderDetails = _dbContext.OrderDetails.Where(s => s.IsMissing == true && s.DateUpdated.Year == DateTime.Now.Year && s.DateUpdated.Month == DateTime.Now.Month && s.DateUpdated.Day == DateTime.Now.Day).ToList();

            //foreach (var item in orders)
            //{
            //    if (item.OrderDetails != null)
            //    {
            //        orderDetails.AddRange(item.OrderDetails);
            //    }
            //}

            //orderDetails = orderDetails.DistinctBy(s => new { s.ItemId, s.OrderId }).OrderByDescending(f => f.DateUpdated).ToList();

            //return _mapper.Map<List<OrderDetail>, List<OrderDetailViewModel>>(orderDetails);
            throw new Exception();
        }
    }
}
