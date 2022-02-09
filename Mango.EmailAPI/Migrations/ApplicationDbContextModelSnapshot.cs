﻿// <auto-generated />
using System;
using Mango.EmailAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mango.EmailAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Mango.EmailAPI.Models.EmailLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Log")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("EmailLogs");
                });
#pragma warning restore 612, 618
        }
    }
}