using AutoMapper;
using Data.DataAccessLayer;
using Data.Entities;
using DataCenter.DataAccess;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;

namespace DataCenter.Services
{
    public interface IRestoreService
    {
        DateTime RestoreFromMongo(string userId);
    }
    public class RestoreService : IRestoreService
    {
        private readonly MongoDbContext _mongoDbContext;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestoreService(MongoDbContext mongoDbContext, AppDbContext dbContext, IMapper mapper)
        {
            _mongoDbContext = mongoDbContext;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DateTime RestoreFromMongo(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new Exception("Vui lòng đăng nhập");
            }
            RemoveAllData();

            var usersBk = _mongoDbContext.Users.Find(f => true).ToList();
            var users = _mapper.Map<List<User>>(usersBk);
            _dbContext.AddRange(users);
            _dbContext.SaveChanges();

            var rolesBk = _mongoDbContext.Roles.Find(f => true).ToList();
            var roles = _mapper.Map<List<IdentityRole>>(rolesBk);
            _dbContext.AddRange(roles);
            _dbContext.SaveChanges();

            var userRolesBk = _mongoDbContext.UserRoles.Find(f => true).ToList();
            var userRoles = _mapper.Map<List<IdentityUserRole<string>>>(userRolesBk);
            _dbContext.AddRange(userRoles);
            _dbContext.SaveChanges();

            var couponsBk = _mongoDbContext.Coupons.Find(f => true).ToList();
            var coupons = _mapper.Map<List<Coupon>>(couponsBk);
            _dbContext.AddRange(coupons);
            _dbContext.SaveChanges();

            var categoryBk = _mongoDbContext.Categories.Find(f => true).ToList();
            var categories = _mapper.Map<List<Category>>(categoryBk);
            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            var itemsBk = _mongoDbContext.Items.Find(f => true).ToList();
            var items = _mapper.Map<List<Item>>(itemsBk);
            _dbContext.AddRange(items);
            _dbContext.SaveChanges();

            var itemImgsBk = _mongoDbContext.ItemImages.Find(f => true).ToList();
            var itemImages = _mapper.Map<List<ItemImage>>(itemImgsBk);
            _dbContext.AddRange(itemImages);
            _dbContext.SaveChanges();

            var floorBk = _mongoDbContext.Floors.Find(f => true).ToList();
            var floors = _mapper.Map<List<Floor>>(floorBk);
            _dbContext.AddRange(floors);
            _dbContext.SaveChanges();

            var tableBk = _mongoDbContext.Tables.Find(f => true).ToList();
            var tables = _mapper.Map<List<Table>>(tableBk);
            _dbContext.AddRange(tables);
            _dbContext.SaveChanges();

            var orderBk = _mongoDbContext.Orders.Find(f => true).ToList();
            var orders = _mapper.Map<List<Order>>(orderBk);
            _dbContext.AddRange(orders);
            _dbContext.SaveChanges();

            var orderDetailBk = _mongoDbContext.OrderDetails.Find(f => true).ToList();
            var orderDetails = _mapper.Map<List<OrderDetail>>(orderDetailBk);
            _dbContext.AddRange(orderDetails);
            _dbContext.SaveChanges();

            var billBk = _mongoDbContext.Bills.Find(f => true).ToList();
            var bills = _mapper.Map<List<Bill>>(billBk);
            _dbContext.AddRange(bills);
            _dbContext.SaveChanges();

            var billOrderBk = _mongoDbContext.BillOrders.Find(f => true).ToList();
            var billOrders = _mapper.Map<List<BillOrder>>(billOrderBk);
            _dbContext.AddRange(billOrders);
            _dbContext.SaveChanges();

            var systemSettingBk = _mongoDbContext.SystemSettings.Find(f => true).ToList();
            var systemSettings = _mapper.Map<List<SystemSetting>>(systemSettingBk);
            _dbContext.AddRange(systemSettings);
            _dbContext.SaveChanges();

            return DateTime.Now;
        }
        private void RemoveAllData()
        {
            _dbContext.SystemSettings.RemoveRange(_dbContext.SystemSettings.ToList());
            _dbContext.SaveChanges();

            _dbContext.Coupons.RemoveRange(_dbContext.Coupons.ToList());
            _dbContext.SaveChanges();

            _dbContext.BillOrders.RemoveRange(_dbContext.BillOrders.ToList());
            _dbContext.SaveChanges();

            _dbContext.Bills.RemoveRange(_dbContext.Bills.ToList());
            _dbContext.SaveChanges();

            _dbContext.OrderDetails.RemoveRange(_dbContext.OrderDetails.ToList());
            _dbContext.SaveChanges();

            _dbContext.Orders.RemoveRange(_dbContext.Orders.ToList());
            _dbContext.SaveChanges();

            _dbContext.ItemImages.RemoveRange(_dbContext.ItemImages.ToList());
            _dbContext.SaveChanges();

            _dbContext.Items.RemoveRange(_dbContext.Items.ToList());
            _dbContext.SaveChanges();

            _dbContext.Categories.RemoveRange(_dbContext.Categories.ToList());
            _dbContext.SaveChanges();

            _dbContext.Tables.RemoveRange(_dbContext.Tables.ToList());
            _dbContext.SaveChanges();

            _dbContext.Floors.RemoveRange(_dbContext.Floors.ToList());
            _dbContext.SaveChanges();

            _dbContext.UserRoles.RemoveRange(_dbContext.UserRoles.ToList());
            _dbContext.SaveChanges();

            _dbContext.Roles.RemoveRange(_dbContext.Roles.ToList());
            _dbContext.SaveChanges();

            _dbContext.Users.RemoveRange(_dbContext.Users.ToList());
            _dbContext.SaveChanges();
        }
    }
}
