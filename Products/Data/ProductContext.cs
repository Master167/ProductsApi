using Microsoft.EntityFrameworkCore;
using Products.Models;
using System.Collections.Generic;

namespace Products.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductContext() { }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("ProductDatebase");
                //base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Toys", IsVisible = true },
                new { Id = 2, Name = "Games", IsVisible = false }
            );

            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Army Man", Price = 10.00, Description = "Army Man", CategoryId = 1 },
                new { Id = 2, Name = "Hot Wheel Car", Price = 2.00, Description = "Drive a car like the adults", CategoryId = 1 },
                new { Id = 3, Name = "Baby Doll", Price = 10.00, Description = "Baby Doll", CategoryId = 1 },
                new { Id = 4, Name = "Mario", Price = 10.00, Description = "Jump Kick Flip", CategoryId = 2 },
                new { Id = 5, Name = "Sonic", Price = 10.00, Description = "Rolling around like the speed", CategoryId = 2 }
            );

        }
    }
}
