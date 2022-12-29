using AutoMapper;
using Data.DataAccessLayer;
using DataCenter.Collections;
using DataCenter.DataAccess;
using MongoDB.Driver;
using System.Reflection;

namespace DataCenter.Services
{
    public interface IBackupService
    {
        DateTime BackupAllData();
        DateTime? LastBackupDate();
    }
    public class BackupService : IBackupService
    {
        private readonly MongoDbContext _mongoDbContext;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public BackupService(MongoDbContext mongoDbContext, AppDbContext dbContext, IMapper mapper, IWebHostEnvironment env)
        {
            _mongoDbContext = mongoDbContext;
            _dbContext = dbContext;
            _mapper = mapper;
            _env = env;
        }

        public DateTime BackupAllData()
        {
            if (!_env.IsProduction())
            {
                throw new Exception("Backup is only for production");
            }
            var lastBackup = _mongoDbContext.BackupDates.Find(f => true).FirstOrDefault();
            DateTime? last = null;
            if (lastBackup != null && lastBackup.LastBackupDate != default && lastBackup.LastBackupDate != null)
            {
                last = lastBackup.LastBackupDate;
                last = DateTime.SpecifyKind(last.Value, DateTimeKind.Unspecified);
            }

            var now = DateTime.UtcNow.AddHours(7);

            var transaction = _mongoDbContext.StartSession();
            transaction.StartTransaction();

            try
            {
                var bills = _dbContext.Bills.Where(f => last == null || f.DateUpdated >= last).ToList();
                var billBk = _mapper.Map<List<Bill>>(bills);
                bills = null;

                if (billBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Bills.Find(f => billBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Bills.FindOneAndReplace(f => f.Id == item.Id, item);
                            billBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Bills.InsertMany(billBk);
                }

                var billOrders = _dbContext.BillOrders.ToList();
                var billOrdersBk = _mapper.Map<List<BillOrder>>(billOrders);
                billOrders = null;

                if (billOrdersBk.Count > 0)
                {
                    _mongoDbContext.BillOrders.DeleteMany(f => true);
                    _mongoDbContext.BillOrders.InsertMany(billOrdersBk);
                }

                var categories = _dbContext.Categories.Where(f => last == null || f.DateUpdated >= last).ToList();
                var categoriesBk = _mapper.Map<List<Category>>(categories);
                categories = null;

                if (categoriesBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Categories.Find(f => categoriesBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Categories.FindOneAndReplace(f => f.Id == item.Id, item);
                            categoriesBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Categories.InsertMany(categoriesBk);
                }

                var coupons = _dbContext.Coupons.Where(f => last == null || f.DateUpdated >= last).ToList();
                var couponsBk = _mapper.Map<List<Coupon>>(coupons);
                coupons = null;

                if (couponsBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Coupons.Find(f => couponsBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Coupons.FindOneAndReplace(f => f.Id == item.Id, item);
                            couponsBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Coupons.InsertMany(couponsBk);
                }

                var floors = _dbContext.Floors.Where(f => last == null || f.DateUpdated >= last).ToList();
                var floorsBk = _mapper.Map<List<Floor>>(floors);
                floors = null;
                if (floorsBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Floors.Find(f => floorsBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Floors.FindOneAndReplace(f => f.Id == item.Id, item);
                            floorsBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Floors.InsertMany(floorsBk);
                }

                var items = _dbContext.Items.Where(f => last == null || f.DateUpdated >= last).ToList();
                var itemBk = _mapper.Map<List<Item>>(items);
                items = null;
                if (itemBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Items.Find(f => itemBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Items.FindOneAndReplace(f => f.Id == item.Id, item);
                            itemBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Items.InsertMany(itemBk);
                }

                var itemImages = _dbContext.ItemImages.Where(f => last == null || f.DateUpdated >= last).ToList();
                var itemImgBk = _mapper.Map<List<ItemImage>>(itemImages);
                itemImages = null;
                if (itemImgBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.ItemImages.Find(f => itemImgBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.ItemImages.FindOneAndReplace(f => f.Id == item.Id, item);
                            itemImgBk.Remove(item);
                        }
                    }
                    _mongoDbContext.ItemImages.InsertMany(itemImgBk);
                }

                var orders = _dbContext.Orders.Where(f => last == null || f.DateUpdated >= last).ToList();
                var orderBk = _mapper.Map<List<Order>>(orders);
                orders = null;
                if (orderBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Orders.Find(f => orderBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Orders.FindOneAndReplace(f => f.Id == item.Id, item);
                            orderBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Orders.InsertMany(orderBk);
                }

                var orderDetails = _dbContext.OrderDetails.Where(f => last == null || f.DateUpdated >= last).ToList();
                var orDetailBk = _mapper.Map<List<OrderDetail>>(orderDetails);
                orderDetails = null;
                if (orDetailBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.OrderDetails.Find(f => orDetailBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.OrderDetails.FindOneAndReplace(f => f.Id == item.Id, item);
                            orDetailBk.Remove(item);
                        }
                    }
                    _mongoDbContext.OrderDetails.InsertMany(orDetailBk);
                }

                var systemSettings = _dbContext.SystemSettings.ToList();
                var stBk = _mapper.Map<List<SystemSetting>>(systemSettings);
                systemSettings = null;
                if (stBk.Count > 0)
                {
                    _mongoDbContext.SystemSettings.DeleteMany(f => true);
                    _mongoDbContext.SystemSettings.InsertMany(stBk);
                }

                var tables = _dbContext.Tables.Where(f => last == null || f.DateUpdated >= last).ToList();
                var tbBk = _mapper.Map<List<Table>>(tables);
                tables = null;
                if (tbBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Tables.Find(f => tbBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Tables.FindOneAndReplace(f => f.Id == item.Id, item);
                            tbBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Tables.InsertMany(tbBk);
                }

                var users = _dbContext.Users.Where(f => last == null || f.DateUpdated >= last).ToList();
                var userBk = _mapper.Map<List<User>>(users);
                users = null;

                if (userBk.Count > 0)
                {
                    var exsitedData = _mongoDbContext.Users.Find(f => userBk.Select(s => s.Id).Contains(f.Id)).ToList();
                    if (exsitedData.Count > 0)
                    {
                        foreach (var item in exsitedData)
                        {
                            _mongoDbContext.Users.FindOneAndReplace(f => f.Id == item.Id, item);
                            userBk.Remove(item);
                        }
                    }
                    _mongoDbContext.Users.InsertMany(userBk);
                }

                var roles = _dbContext.Roles.ToList();
                var roleBk = _mapper.Map<List<Role>>(roles);
                roles = null;

                if (roleBk.Count > 0)
                {
                    _mongoDbContext.Roles.DeleteMany(f => true);
                    _mongoDbContext.Roles.InsertMany(roleBk);
                }

                var userRoles = _dbContext.UserRoles.ToList();
                var userRoleBk = _mapper.Map<List<UserRole>>(userRoles);
                userRoles = null;

                if (userRoleBk.Count > 0)
                {
                    _mongoDbContext.UserRoles.DeleteMany(f => true);
                    _mongoDbContext.UserRoles.InsertMany(userRoleBk);
                }

                if (lastBackup == null)
                {
                    lastBackup = new BackupDate() { LastBackupDate = now };
                    _mongoDbContext.BackupDates.InsertOne(lastBackup);
                }
                else
                {
                    lastBackup.LastBackupDate = now;
                    _mongoDbContext.BackupDates.FindOneAndReplace(f => f.Id == lastBackup.Id, lastBackup);
                }
                transaction.CommitTransaction();
            }
            catch (Exception e)
            {
                transaction.AbortTransaction();
                throw new Exception(e.Message);
            }
            finally
            {
                transaction.Dispose();
            }
            return now;
        }
        public DateTime? LastBackupDate()
        {
            return _mongoDbContext.BackupDates.Find(f => true).First().LastBackupDate;
        }
    }
}
