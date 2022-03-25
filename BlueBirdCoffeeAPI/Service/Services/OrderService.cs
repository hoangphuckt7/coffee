using AutoMapper;
using Data.AppException;
using Data.Cache;
using Data.DataAccessLayer;
using Data.Entities;
using Data.Enums;
using Data.ViewModels;
using Hub;
using Microsoft.AspNetCore.Identity;
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
    }
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly INotificationHub _notificationHub;
        private readonly UserManager<User> _userManager;

        public OrderService(AppDbContext dbContext, IMapper mapper, INotificationHub notificationHub, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _notificationHub = notificationHub;
            _userManager = userManager;
        }

        public async Task<Guid> CreateOrder(string employeeId, OrderCreateModel models)
        {
            var transaction = _dbContext.Database.BeginTransaction();

            var order = new Order()
            {
                TableId = models.TableId,
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
                        Description = itemDetail.Description,
                        ItemId = itemDetail.Id,
                        OrderId = order.Id,
                        Price = itemDetail.Price,
                        Quantity = item.Quantity
                    };

                    _dbContext.Add(newOrderDetail);
                }

                _dbContext.SaveChanges();

                var table = _dbContext.Tables.FirstOrDefault(f => f.Id == order.TableId);
                if (table != null) throw new AppException("Mã số bàn không hợp lệ!");

                table.IsAvailable = false;
                _dbContext.SaveChanges();

                transaction.Commit();

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
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }

            return order.Id;
        }
    }
}
