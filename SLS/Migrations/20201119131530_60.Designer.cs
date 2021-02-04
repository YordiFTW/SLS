﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SLS;

namespace SLS.Migrations
{
    [DbContext(typeof(SLSDbContext))]
    [Migration("20201119131530_60")]
    partial class _60
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SLS.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SLS.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("WhiskyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WhiskyId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SLS.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("SLS.Whisky", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AlcoholPercentage")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Whiskies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 20,
                            AlcoholPercentage = 40,
                            IsDeleted = false,
                            Location = "Speyside",
                            Name = "Jack Daniel's",
                            PhotoPath = "2.png",
                            Price = 30m,
                            Stock = 1,
                            Type = 5
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            AlcoholPercentage = 60,
                            IsDeleted = false,
                            Location = "Lowland",
                            Name = "Crown Royal",
                            PhotoPath = "1.png",
                            Price = 40m,
                            Stock = 1,
                            Type = 3
                        },
                        new
                        {
                            Id = 3,
                            Age = 40,
                            AlcoholPercentage = 80,
                            IsDeleted = false,
                            Location = "Highland",
                            Name = "Jim Beam Bourbon",
                            PhotoPath = "3.png",
                            Price = 50m,
                            Stock = 1,
                            Type = 1
                        });
                });

            modelBuilder.Entity("SLS.Models.Item", b =>
                {
                    b.HasOne("SLS.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("SLS.Whisky", "Whisky")
                        .WithMany()
                        .HasForeignKey("WhiskyId");

                    b.Navigation("Customer");

                    b.Navigation("Whisky");
                });
#pragma warning restore 612, 618
        }
    }
}
