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
        Guid SetCompletedOrder(Guid orderId);
        Guid SetUnCompletedOrder(Guid orderId);
        List<OrderViewModel> GetUnknowLocaltionOrders();
        List<OrderViewModel> TodayCompletedOrders(int count);
        object GetBartenderOrders(int count);
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
                OrderNumber = GetCurrentOrderNumber()
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
                .Where(o => o.TableId == tableId && o.IsDeleted == false && o.IsCheckout == false)
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
            var order = _dbContext.Orders.FirstOrDefault(f => model.OrderIds.Contains(f.Id));
            if (order == null) throw new AppException("Invalid order id");

            order.IsMissing = true;
            order.EmployeeId = emp;

            order.DateUpdated = DateTime.Now;

            _dbContext.Update(order);
            _dbContext.SaveChanges();

            return order.Id;
        }

        public List<OrderViewModel> GetCurrentOrders()
        {
            var ordres = _dbContext.Orders.Include(f => f.OrderDetails).Include(f => f.Table).Where(s => s.IsCheckout == false && s.IsCompleted == false && s.IsDeleted == false && s.IsMissing == false).OrderBy(f => f.DateCreated).ToList();
            return _mapper.Map<List<Order>, List<OrderViewModel>>(ordres);
        }

        public Guid SetCompletedOrder(Guid orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(f => f.Id == orderId);
            if (order == null) throw new AppException("Invalid order id");

            order.IsCompleted = true;
            order.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(order);
            _dbContext.SaveChanges();

            return order.Id;
        }

        public Guid SetUnCompletedOrder(Guid orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(f => f.Id == orderId);
            if (order == null) throw new AppException("Invalid order id");

            order.IsCompleted = false;
            order.DateUpdated = DateTime.UtcNow.AddHours(7);

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
    }
}
