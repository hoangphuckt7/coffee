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
        Guid SetMissingOrder(SetMissingOrders model, string emp);
        List<OrderViewModel> GetByIds(List<Guid> ids);
        List<OrderViewModel> GetCurrentOrders();
        Guid SetCompletedOrder(Guid orderId, string empId);
        Guid SetUnCompletedOrder(Guid orderId, string empId);
        List<OrderViewModel> GetUnknowLocaltionOrders();
        List<OrderViewModel> TodayCompletedOrders(int count);
        object GetBartenderOrders(int count);
        void RemoveMissingOrders();
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
                OrderNumber = GetCurrentOrderNumber(),
                EmployeeId = employeeId
            };

            try
            {
                _dbContext.Add(order);

                foreach (var item in models.OrderDetail)
                {
                    var itemDetail = _dbContext.Items.FirstOrDefault(f => f.Id == item.ItemId);

                    var newOrderDetail = new OrderDetail()
                    {
                        Description = item.Description,
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
                var cashers = await _userManager.GetUsersInRoleAsync(SystemRoles.CASHIER);
                foreach (var casher in cashers)
                {
                    await _tableHub.ChangeStatus(_mapper.Map<TableViewModel>(table), casher.Id);
                }
            }

            return order.Id;
        }
        public int GetCurrentOrderNumber()
        {
            var lastestOrder = _dbContext.Orders.OrderByDescending(s => s.DateCreated).FirstOrDefault();

            if (lastestOrder != null && lastestOrder.DateCreated.Date == DateTime.UtcNow.AddHours(7).Date)
            {
                return lastestOrder.OrderNumber + 1;
            }

            return 1;
        }
        public List<OrderViewModel> GetByTable(Guid tableId)
        {
            var orders = _dbContext.Orders
                //.Include(f => f.OrderDetails)
                .Where(o => o.TableId == tableId && o.IsDeleted == false && o.IsCheckout == false && o.IsMissing == false)
                .ToList();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
        public List<OrderViewModel> TodayCompletedOrders(int count)
        {
            var orders = _dbContext.Orders
                .Include(f => f.OrderDetails)
                .Where(o => o.DateCreated.Date == DateTime.UtcNow.AddHours(7).Date && o.IsCompleted == true)
                .OrderByDescending(o => o.DateUpdated)
                .Take(count)
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
            var order = _dbContext.Orders.FirstOrDefault(f => model.OrderId == f.Id);
            if (order == null) throw new AppException("Invalid order id");

            order.IsMissing = true;
            order.EmployeeId = emp;

            var orderDetails = _dbContext.OrderDetails.Where(s => s.OrderId == model.OrderId).ToList();

            foreach (var item in orderDetails)
            {
                item.FinalQuantity = 0;
                item.MissingReason = model.Reason;

                item.DateUpdated = DateTime.UtcNow.AddHours(7);

                _dbContext.Update(item);
            }

            if (order.TableId != null)
            {
                var table = _dbContext.Tables.First(f => order.TableId == f.Id);
                table.CurrentOrder -= 1;

                _dbContext.Update(table);
            }

            order.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(order);
            _dbContext.SaveChanges();

            return order.Id;
        }
        public List<OrderViewModel> GetCurrentOrders()
        {
            var ordres = _dbContext.Orders.Include(f => f.OrderDetails).Include(f => f.Table).Where(s => s.IsCheckout == false && s.IsCompleted == false && s.IsDeleted == false && s.IsMissing == false).OrderBy(f => f.DateCreated).ToList();
            return _mapper.Map<List<Order>, List<OrderViewModel>>(ordres);
        }
        public Guid SetCompletedOrder(Guid orderId, string empId)
        {
            var order = _dbContext.Orders.FirstOrDefault(f => f.Id == orderId);
            if (order == null) throw new AppException("Invalid order id");

            order.IsCompleted = true;
            order.DateUpdated = DateTime.UtcNow.AddHours(7);
            order.BartenderId = empId;

            _dbContext.Update(order);
            _dbContext.SaveChanges();

            return order.Id;
        }
        public Guid SetUnCompletedOrder(Guid orderId, string empId)
        {
            var order = _dbContext.Orders.FirstOrDefault(f => f.Id == orderId);
            if (order == null) throw new AppException("Invalid order id");

            order.IsCompleted = false;
            order.DateUpdated = DateTime.UtcNow.AddHours(7);
            order.BartenderId = empId;

            _dbContext.Update(order);
            _dbContext.SaveChanges();

            return order.Id;
        }
        public List<OrderViewModel> GetUnknowLocaltionOrders()
        {
            var orders = _dbContext.Orders
                //.Include(f => f.OrderDetails)
                .Where(o => o.TableId == null && o.IsDeleted == false && o.IsCheckout == false)
                .ToList();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
        public object GetBartenderOrders(int count)
        {
            return new
            {
                ListOrderNew = GetCurrentOrders(),
                ListOrderCompleted = TodayCompletedOrders(count),
            };
        }
        public void RemoveMissingOrders()
        {
            var now = DateTime.UtcNow.AddHours(7);

            var orders = _dbContext.Orders
                .Where(s => s.DateCreated.AddHours(8) <= now && s.IsCheckout == false && s.IsDeleted == false && s.IsRejected == false)
                .ToList();

            var orderDetails = _dbContext.OrderDetails.Where(s => orders.Select(s => s.Id).Contains(s.OrderId)).ToList();

            foreach (var order in orders)
            {
                order.IsMissing = true;
                order.DateUpdated = DateTime.UtcNow.AddHours(7);

                if (order.TableId != null)
                {
                    var table = _dbContext.Tables.FirstOrDefault(f => f.Id == order.TableId);
                    if (table != null)
                    {
                        table.CurrentOrder -= 1;
                        _dbContext.Tables.Update(table);
                    }
                }

                _dbContext.Orders.Update(order);
            }

            foreach (var orderDetail in orderDetails)
            {
                orderDetail.FinalQuantity = 0;
                orderDetail.DateUpdated = DateTime.UtcNow.AddHours(7);
                orderDetail.MissingReason = "Quá thời gian";

                _dbContext.OrderDetails.Update(orderDetail);
            }

            var tables = _dbContext.Tables.Where(f => f.CurrentOrder < 0).ToList();
            foreach (var table in tables)
            {
                table.CurrentOrder = 0;
                _dbContext.Update(table);
            }

            _dbContext.SaveChanges();
        }
    }
}
