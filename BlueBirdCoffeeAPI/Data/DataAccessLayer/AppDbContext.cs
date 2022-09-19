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
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Bill>().HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            //modelBuilder.Entity<Bill>().HasOne(x => x.Casher).WithMany().HasForeignKey(x => x.CasherId);
            //modelBuilder.Entity<Bill>().HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);

            #region Double FK, PK
            modelBuilder.Entity<OrderDetail>().HasKey(s => new { s.OrderId, s.ItemId });
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
        }
    }
}
