using DataCenter.Collections;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace DataCenter.DataAccess
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _db;
        private IMongoClient _mongoClient;

        public MongoDbContext(IMongoClient client, string databaseName)
        {
            _db = client.GetDatabase(databaseName);
            _mongoClient = client;
        }

        public IMongoCollection<BackupDate> BackupDates => _db.GetCollection<BackupDate>("backup_dates");
        public IMongoCollection<Bill> Bills => _db.GetCollection<Bill>("bills");
        public IMongoCollection<BillOrder> BillOrders => _db.GetCollection<BillOrder>("bill_orders");
        public IMongoCollection<Category> Categories => _db.GetCollection<Category>("categories");
        public IMongoCollection<Coupon> Coupons => _db.GetCollection<Coupon>("coupons");
        public IMongoCollection<Floor> Floors => _db.GetCollection<Floor>("floors");
        public IMongoCollection<Item> Items => _db.GetCollection<Item>("items");
        public IMongoCollection<ItemImage> ItemImages => _db.GetCollection<ItemImage>("item_images");
        public IMongoCollection<Order> Orders => _db.GetCollection<Order>("orders");
        public IMongoCollection<OrderDetail> OrderDetails => _db.GetCollection<OrderDetail>("order_details");
        public IMongoCollection<Role> Roles => _db.GetCollection<Role>("roles");
        public IMongoCollection<SystemSetting> SystemSettings => _db.GetCollection<SystemSetting>("system_settings");
        public IMongoCollection<Table> Tables => _db.GetCollection<Table>("tables");
        public IMongoCollection<User> Users => _db.GetCollection<User>("users");
        public IMongoCollection<UserRole> UserRoles => _db.GetCollection<UserRole>("user_roles");

        public IClientSessionHandle StartSession()
        {
            return _mongoClient.StartSession();
        }

        public void CreateCollectionsIfNotExists()
        {
            var collectionNames = _db.ListCollectionNames().ToList();

            if (!collectionNames.Any(name => name == "backup_dates"))
            {
                _db.CreateCollection("backup_dates");
            }
            if (!collectionNames.Any(name => name == "bills"))
            {
                _db.CreateCollection("bills");
            }
            if (!collectionNames.Any(name => name == "bill_orders"))
            {
                _db.CreateCollection("bill_orders");
            }
            if (!collectionNames.Any(name => name == "categories"))
            {
                _db.CreateCollection("categories");
            }
            if (!collectionNames.Any(name => name == "coupons"))
            {
                _db.CreateCollection("coupons");
            }
            if (!collectionNames.Any(name => name == "floors"))
            {
                _db.CreateCollection("floors");
            }
            if (!collectionNames.Any(name => name == "items"))
            {
                _db.CreateCollection("items");
            }
            if (!collectionNames.Any(name => name == "item_images"))
            {
                _db.CreateCollection("item_images");
            }
            if (!collectionNames.Any(name => name == "orders"))
            {
                _db.CreateCollection("orders");
            }
            if (!collectionNames.Any(name => name == "order_details"))
            {
                _db.CreateCollection("order_details");
            }
            if (!collectionNames.Any(name => name == "roles"))
            {
                _db.CreateCollection("roles");
            }
            if (!collectionNames.Any(name => name == "system_settings"))
            {
                _db.CreateCollection("system_settings");
            }
            if (!collectionNames.Any(name => name == "tables"))
            {
                _db.CreateCollection("tables");
            }
            if (!collectionNames.Any(name => name == "users"))
            {
                _db.CreateCollection("users");
            }
            if (!collectionNames.Any(name => name == "user_roles"))
            {
                _db.CreateCollection("user_roles");
            }
        }
    }
}
