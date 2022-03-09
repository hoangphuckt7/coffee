using Data.Entities;
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
        //public virtual DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Double FK, PK
            //modelBuilder.Entity<SupplierProduct>().HasKey(s => new { s.ProductId, s.SupplierId });
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
