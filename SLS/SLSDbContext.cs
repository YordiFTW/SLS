using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SLS;
using SLS.Helper;
using SLS.Models;

namespace SLS
{
    public class SLSDbContext : DbContext
    {
        public SLSDbContext(DbContextOptions<SLSDbContext> options)
            : base(options)
        {

        }

        public DbSet<Whisky> Whiskies { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Personnel> Personnel { get; set; }

        public DbSet<Item> Item { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Personnel>().HasData(
               // new Personnel { Id = 1, Firstname = "Anna", Middlename = "ter", Lastname = "Nas" },
                //new Personnel { Id = 1, Firstname = "Co", Middlename = "", Lastname = "Mies" },
                //new Personnel { Id = 1, Firstname = "Bas", Middlename = "", Lastname = "Sillen" }
               // );
            //modelBuilder.Entity<Customer>().HasData(
                //new Customer { Id = 1, Firstname = "Beau", Middlename = "ter", Lastname = "Ham" },
                //new Customer { Id = 1, Firstname = "Connie", Middlename = "", Lastname = "Veren" },
                //new Customer { Id = 1, Firstname = "Hans", Middlename = "", Lastname = "Schoen" }
               // );
            modelBuilder.Entity<Whisky>().HasData(
                new Whisky { Id = 1, Name = "Jack Daniel's", Age = 20, Location = "Speyside", AlcoholPercentage = 40, PhotoPath = "2.png", Stock = 1, Price = 30, Type = WhiskyType.Blended },
                new Whisky { Id = 2, Name = "Crown Royal", Age = 30, Location = "Lowland", AlcoholPercentage = 60, PhotoPath = "1.png", Stock = 1, Price = 40, Type = WhiskyType.singleCask },
                new Whisky { Id = 3, Name = "Jim Beam Bourbon", Age = 40, Location = "Highland", AlcoholPercentage = 80, PhotoPath = "3.png", Stock = 1, Price = 50, Type = WhiskyType.singleMalt }
                );

            //modelBuilder.Entity<CustomerOrder>()
                //.HasKey(c => new { c.CustomerId, c.ItemId });
        }
    }
}
