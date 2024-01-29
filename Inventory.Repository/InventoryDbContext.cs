using Inventory.Core.Models;
using Inventory.Repository.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository
{
    public class InventoryDbContext : IdentityDbContext<Users, Roles, int>
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<StockedProduct> StockedProducts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<ProductCategoryMap> ProductCategoryMaps { get; set; }

        public DbSet<StockedProductUnitMap> StockedProductUnitMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductCategoryMap>().HasKey(x => new { x.ProductId, x.CategoryId });
            builder.Entity<StockedProductUnitMap>().Property(x => x.weight).HasColumnType("decimal(18,2)");

            builder.Entity<Unit>().Property(x => x.ConversionFactor).HasColumnType("decimal(18,2)");


            builder.Entity<IdentityUserLogin<int>>().ToTable("EnventoryUserLogin").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<int>>().ToTable("EnventoryUserRole").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserToken<int>>().ToTable("EnventoryUserToken").HasKey(x => x.UserId);
            builder.Entity<IdentityUserClaim<int>>().ToTable("EnventoryUserClaim");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("EnventoryRoleClaim");
            builder.Entity<IdentityRole<int>>().ToTable("EnventoryRole");
            builder.Entity<IdentityUser<int>>().ToTable("EnventoryUser");

            builder.Entity<Roles>().HasData(
                new Roles { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new Roles { Id = 2, Name = "User", NormalizedName = "USER" }
                );

            Users user1 = new()
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "info@admin.com",
                NormalizedEmail = "INFO@ADMIN.COM",
                PhoneNumber = "123456789",
            };
            user1.PasswordHash = new PasswordHasher<Users>().HashPassword(user1, "123456");
            user1.SecurityStamp = Guid.NewGuid().ToString();
            builder.Entity<Users>().HasData(user1);

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 1, UserId = 1 });
        }
    }
}
