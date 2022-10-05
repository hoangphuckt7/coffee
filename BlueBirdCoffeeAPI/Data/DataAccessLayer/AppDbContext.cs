using Data.Cache;
using Data.Entities;
using Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Entities
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillOrder> BillOrders { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Bill>().HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            //modelBuilder.Entity<Bill>().HasOne(x => x.Casher).WithMany().HasForeignKey(x => x.CasherId);
            //modelBuilder.Entity<Bill>().HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);

            #region Double FK, PK
            modelBuilder.Entity<OrderDetail>().HasKey(s => new { s.OrderId, s.ItemId });
            modelBuilder.Entity<BillOrder>().HasKey(s => new { s.OrderId, s.BillId });
            #endregion

            #region Seed
            modelBuilder.Entity<SystemSetting>().HasData(
                new SystemSetting()
                {
                    Key = MandatorySettings.ORDER_RECEIVER.ToString(),
                    Value = JsonConvert.SerializeObject(new List<string>() { SystemRoles.BARTENDER })
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = SystemRoles.ADMIN, Name = SystemRoles.ADMIN, NormalizedName = SystemRoles.ADMIN, ConcurrencyStamp = SystemRoles.ADMIN },
                new IdentityRole() { Id = SystemRoles.BARTENDER, Name = SystemRoles.BARTENDER, NormalizedName = SystemRoles.BARTENDER, ConcurrencyStamp = SystemRoles.BARTENDER },
                new IdentityRole() { Id = SystemRoles.CUSTOMER, Name = SystemRoles.CUSTOMER, NormalizedName = SystemRoles.CUSTOMER, ConcurrencyStamp = SystemRoles.CUSTOMER },
                new IdentityRole() { Id = SystemRoles.EMPLOYEE, Name = SystemRoles.EMPLOYEE, NormalizedName = SystemRoles.EMPLOYEE, ConcurrencyStamp = SystemRoles.EMPLOYEE },
                new IdentityRole() { Id = SystemRoles.CASHER, Name = SystemRoles.CASHER, NormalizedName = SystemRoles.CASHER, ConcurrencyStamp = SystemRoles.CASHER });

            modelBuilder.Entity<Floor>().HasData(
                new Floor()
                {
                    Id = Guid.Parse("eb22e2ea-0305-4778-a129-f400e6a64447"),
                    Description = "Tầng 1"
                }, new Floor()
                {
                    Id = Guid.Parse("eb22e2ea-0305-4778-a129-f400e6a64445"),
                    Description = "Tầng 2"
                });
            #endregion

            #region Menu
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1"), Description = "Cà phê truyền thống", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2"), Description = "Cà phê ép máy", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3"), Description = "Cà phê đặc biệt", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4"), Description = "Nước ép", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5"), Description = "Sinh tố", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6"), Description = "Trà sữa", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7"), Description = "Trà nóng", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8"), Description = "Trà trà", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) },
                new Category() { Id = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9"), Description = "Ăn vặt", DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7) }
                );

            modelBuilder.Entity<Item>().HasData(
                new Item() { Id = Guid.Parse("16d3154f-b5e8-4b00-9262-a4215b43f6ee"), Name = "Cà phê đen phin", Price = 12000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1") },
                new Item() { Id = Guid.Parse("26d3154f-b5e8-4b00-9262-a4215b43f6ee"), Name = "Cà phê sữa phin", Price = 14000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1") },
                new Item() { Id = Guid.Parse("36d3154f-b5e8-4b00-9262-a4215b43f6ee"), Name = "Cà phê đen đá Sài Gòn", Price = 18000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1") },
                new Item() { Id = Guid.Parse("46d3154f-b5e8-4b00-9262-a4215b43f6ee"), Name = "Cà phê sữa đá Sài Gòn", Price = 20000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1") },
                new Item() { Id = Guid.Parse("56d3154f-b5e8-4b00-9262-a4215b43f6ee"), Name = "Bạc xỉu", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1") },
                new Item() { Id = Guid.Parse("66d3154f-b5e8-4b00-9262-a4215b43f6ee"), Name = "Ca cao nóng - đá", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b1") },

                new Item() { Id = Guid.Parse("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b1"), Name = "Cà phê đen máy", Price = 16000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2") },
                new Item() { Id = Guid.Parse("ff64e1d2-a0e7-40a9-9bb1-d01a19bea5b2"), Name = "Cà phê sữa máy", Price = 18000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b2") },

                new Item() { Id = Guid.Parse("1929dacf-d25a-4a8d-b647-c9a29d3d552b"), Name = "Cà phê kem trứng muối", Price = 29000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3") },
                new Item() { Id = Guid.Parse("2929dacf-d25a-4a8d-b647-c9a29d3d552b"), Name = "Cà phê cốt dừa", Price = 29000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3") },
                new Item() { Id = Guid.Parse("3929dacf-d25a-4a8d-b647-c9a29d3d552b"), Name = "Cà phê trứng", Price = 29000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3") },
                new Item() { Id = Guid.Parse("4929dacf-d25a-4a8d-b647-c9a29d3d552b"), Name = "Cappuchino", Price = 29000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b3") },

                new Item() { Id = Guid.Parse("c3667f70-c2b7-4af9-8300-ad54c79e841a"), Name = "Nước ép dưa hấu", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4") },
                new Item() { Id = Guid.Parse("c3667f70-c2b7-4af9-8300-ad54c79e842a"), Name = "Nước ép cà rốt", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4") },
                new Item() { Id = Guid.Parse("c3667f70-c2b7-4af9-8300-ad54c79e843a"), Name = "Nước ép thơm", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4") },
                new Item() { Id = Guid.Parse("c3667f70-c2b7-4af9-8300-ad54c79e844a"), Name = "Nước ép cam", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b4") },

                new Item() { Id = Guid.Parse("1649ec15-fcec-4368-83f9-5b16f43fee5b"), Name = "Sinh tố bơ", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5") },
                new Item() { Id = Guid.Parse("2649ec15-fcec-4368-83f9-5b16f43fee5b"), Name = "Sinh tố bơ sầu riêng", Price = 35000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5") },
                new Item() { Id = Guid.Parse("3649ec15-fcec-4368-83f9-5b16f43fee5b"), Name = "Sinh tố xoài", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5") },
                new Item() { Id = Guid.Parse("4649ec15-fcec-4368-83f9-5b16f43fee5b"), Name = "Sinh tố dâu tây", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b5") },

                new Item() { Id = Guid.Parse("d135806f-52da-434f-840b-ae253b0fbbff"), Name = "Trà sữa truyền thống", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6") },
                new Item() { Id = Guid.Parse("d235806f-52da-434f-840b-ae253b0fbbff"), Name = "Trà sữa kem trứng muối", Price = 29000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6") },
                new Item() { Id = Guid.Parse("d335806f-52da-434f-840b-ae253b0fbbff"), Name = "Trà sữa khoai môn", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b6") },

                new Item() { Id = Guid.Parse("d18ca698-10a5-42e3-b044-3bdd2e5d81bd"), Name = "Trà olong cúc mật ong nóng", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7") },
                new Item() { Id = Guid.Parse("d28ca698-10a5-42e3-b044-3bdd2e5d81bd"), Name = "Trà hoa cúc nóng", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7") },
                new Item() { Id = Guid.Parse("d38ca698-10a5-42e3-b044-3bdd2e5d81bd"), Name = "Trà chanh nóng", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b7") },

                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48321"), Name = "Trà chanh", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48322"), Name = "Trà chanh dây", Price = 22000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48323"), Name = "Trà lipton nóng - đá", Price = 20000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48324"), Name = "Trà gừng nóng - đá", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48325"), Name = "Trà đào cam xả", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48326"), Name = "Trà vải", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48327"), Name = "Trà sen macchiato", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48328"), Name = "Trà đen macchiato", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },
                new Item() { Id = Guid.Parse("5020bd91-1caf-4868-9fe5-9a1360c48329"), Name = "Trà dâu", Price = 25000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b8") },

                new Item() { Id = Guid.Parse("1afeafff-f9d3-4a88-8a03-950482af826f"), Name = "Bắp rang bơ", Price = 15000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9") },
                new Item() { Id = Guid.Parse("2afeafff-f9d3-4a88-8a03-950482af826f"), Name = "Bắp rang bơ caramel", Price = 20000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9") },
                new Item() { Id = Guid.Parse("3afeafff-f9d3-4a88-8a03-950482af826f"), Name = "Bắp rang bơ phô mai", Price = 20000, IsDeleted = false, DateCreated = DateTime.UtcNow.AddHours(7), DateUpdated = DateTime.UtcNow.AddHours(7), Available = true, CategoryId = Guid.Parse("4f16c29d-f0dd-4c41-8481-48f32d4cd5b9") }
                );
            #endregion
        }
    }
}
