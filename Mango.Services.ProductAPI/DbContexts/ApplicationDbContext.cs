using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext: DbContext
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
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/1.jpg",
                CategoryName = "Appetizer"
            });
            
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Cup Cake",
                Price = 18,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/3.jpg",
                CategoryName = "Appetizer"
            });
            
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Shawarma",
                Price = 22,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/2.jpg",
                CategoryName = "Appetizer"
            });
            
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pizza",
                Price = 16,
                Description = "Shit",
                ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/4.jpg",
                CategoryName = "Appetizer"
            });
        }
    }
}
