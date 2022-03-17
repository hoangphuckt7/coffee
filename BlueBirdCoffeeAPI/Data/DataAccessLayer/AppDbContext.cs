﻿using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bill>().HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<Bill>().HasOne(x => x.Casher).WithMany().HasForeignKey(x => x.CasherId);
            modelBuilder.Entity<Bill>().HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId);

            #region Double FK, PK
            modelBuilder.Entity<OrderDetail>().HasKey(s => new { s.OrderId, s.ItemId });
            #endregion

            #region Seed User
            //modelBuilder.Entity<UserStatus>().HasData(
            //    new UserStatus() { Id = -1, Description = "Rejected" },
            //    new UserStatus() { Id = 0, Description = "Pending" },
            //    new UserStatus() { Id = 1, Description = "Active" },
            //    new UserStatus() { Id = 2, Description = "Banned" });
            #endregion
        }
    }
}
