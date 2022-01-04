using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.ProductAPI.Data.Models;

namespace Mango.ProductAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/a.jpg",
                CategoryName = "Appetizer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Cup Cake",
                Price = 18,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/b.jpg",
                CategoryName = "Appetizer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Shawarma",
                Price = 22,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/c.jpg",
                CategoryName = "Appetizer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pizza",
                Price = 16,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/d.jpg",
                CategoryName = "Appetizer"
            });
        }
    }
}
