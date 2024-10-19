using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEShop_Core8.Models;

namespace MyEShop_Core8.Data
{
    public class MyEShopContext : DbContext
    {
        public MyEShopContext(DbContextOptions<MyEShopContext> options):base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryToProduct> categoryToProducts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> ordersDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.Productid,t.Categoryid});

            // Seed Data برای جدول Category
            modelBuilder.Entity<Category>().HasData(
                new Category { id = 1, name = "برنامه نویسی", description = "برنامه نویسی دنیایی از ساختنه" },
                new Category { id = 2, name = "کتاب الکترونیک", description = "کتاب های آنلاین" },
                new Category { id = 3, name = "لباس", description = "لباس زن و مرد" }
            );

            // Seed Data برای جدول Users
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserID = 1,
                    Email = "admin@example.com",
                    Password = "admin123", // در پروژه واقعی، رمز عبور را هش میشود
                    RegisterDate = DateTime.UtcNow,
                    IsAdmin = true
                },
                new Users
                {
                    UserID = 2,
                    Email = "user1@example.com",
                    Password = "123",
                    RegisterDate = DateTime.UtcNow.AddDays(-10),
                    IsAdmin = false
                }
            );

            base.OnModelCreating(modelBuilder);
        }


        

    }
}
