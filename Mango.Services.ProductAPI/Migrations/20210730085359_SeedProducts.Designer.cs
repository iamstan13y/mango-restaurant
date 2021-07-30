﻿// <auto-generated />
using Mango.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mango.Services.ProductAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210730085359_SeedProducts")]
    partial class SeedProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Mango.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Appetizer",
                            Description = "Shit",
                            ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/1.jpg",
                            Name = "Samosa",
                            Price = 15.0
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Appetizer",
                            Description = "Shit",
                            ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/3.jpg",
                            Name = "Cup Cake",
                            Price = 18.0
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "Appetizer",
                            Description = "Shit",
                            ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/2.jpg",
                            Name = "Shawarma",
                            Price = 22.0
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryName = "Appetizer",
                            Description = "Shit",
                            ImageUrl = "https://thegnatbug.blob.core.windows.net/mango/4.jpg",
                            Name = "Pizza",
                            Price = 16.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
