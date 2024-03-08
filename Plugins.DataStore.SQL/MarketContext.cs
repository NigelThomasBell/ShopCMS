using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Refreshing drinks" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Freshly baked goods" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Quality meats" },
                new Category { CategoryId = 4, Name = "Dairy", Description = "Dairy products" },
                new Category { CategoryId = 5, Name = "Produce", Description = "Fresh fruits and vegetables" },
                new Category { CategoryId = 6, Name = "Snacks", Description = "Snack items" },
                new Category { CategoryId = 7, Name = "Frozen Foods", Description = "Frozen delights" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Orange Juice", Quantity = 100, Price = 1.99 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Cola", Quantity = 200, Price = 1.99 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Bread", Quantity = 300, Price = 1.50 },
                new Product { ProductId = 4, CategoryId = 3, Name = "Chicken Legs", Quantity = 400, Price = 10.50 },
                new Product { ProductId = 5, CategoryId = 3, Name = "Lamb Chops", Quantity = 300, Price = 20.50 },
                new Product { ProductId = 6, CategoryId = 4, Name = "Milk", Quantity = 150, Price = 2.50 },
                new Product { ProductId = 7, CategoryId = 4, Name = "Cheese", Quantity = 100, Price = 3.99 },
                new Product { ProductId = 8, CategoryId = 5, Name = "Apples", Quantity = 250, Price = 0.75 },
                new Product { ProductId = 9, CategoryId = 5, Name = "Pears", Quantity = 50, Price = 0.75 },
                new Product { ProductId = 10, CategoryId = 5, Name = "Bananas", Quantity = 70, Price = 0.50 },
                new Product { ProductId = 11, CategoryId = 5, Name = "Grapes", Quantity = 40, Price = 1.25 },
                new Product { ProductId = 12, CategoryId = 5, Name = "Strawberries", Quantity = 30, Price = 2.00 },
                new Product { ProductId = 13, CategoryId = 5, Name = "Lettuce", Quantity = 25, Price = 1.00 },
                new Product { ProductId = 14, CategoryId = 5, Name = "Tomatoes", Quantity = 35, Price = 1.50 },
                new Product { ProductId = 15, CategoryId = 5, Name = "Cucumbers", Quantity = 20, Price = 0.75 },
                new Product { ProductId = 16, CategoryId = 5, Name = "Carrots", Quantity = 45, Price = 0.80 },
                new Product { ProductId = 17, CategoryId = 5, Name = "Bell Peppers", Quantity = 30, Price = 1.25 },
                new Product { ProductId = 18, CategoryId = 5, Name = "Spinach", Quantity = 25, Price = 1.25 },
                new Product { ProductId = 19, CategoryId = 7, Name = "Ice Cream", Quantity = 120, Price = 2.25 },
                new Product { ProductId = 20, CategoryId = 7, Name = "Frozen Pizza", Quantity = 80, Price = 4.99 }
            );
        }
    }
}
