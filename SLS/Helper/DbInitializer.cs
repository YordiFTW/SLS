using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLS.Helper
{
    public class DbInitializer
    {
        public static void Initialize(SLSDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Whiskies.Any())
            {
                return;   // DB has been seeded
            }

            var whiskies = new Whisky[]
            {
                new Whisky { Id = 1, Name = "Jack Daniel's", Age = 20, Location = "Speyside", AlcoholPercentage = 40, PhotoPath = "2.png", Stock = 1, Price = 30, Type = WhiskyType.Blended },
                new Whisky { Id = 2, Name = "Crown Royal", Age = 30, Location = "Lowland", AlcoholPercentage = 60, PhotoPath = "1.png", Stock = 1, Price = 40, Type = WhiskyType.singleCask },
                new Whisky { Id = 3, Name = "Jim Beam Bourbon", Age = 40, Location = "Highland", AlcoholPercentage = 80, PhotoPath = "3.png", Stock = 1, Price = 50, Type = WhiskyType.singleMalt }
            };

            context.Whiskies.AddRange(whiskies);
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer { Id = 1, Firstname = "Beau", Middlename = "ter", Lastname = "Ham" },
                new Customer { Id = 1, Firstname = "Connie", Middlename = "", Lastname = "Veren" },
                new Customer { Id = 1, Firstname = "Hans", Middlename = "", Lastname = "Schoen" }
            };

            context.Customer.AddRange(customers);
            context.SaveChanges();

            var personnel = new Personnel[]
            {
                new Personnel { Id = 1, Firstname = "Anna", Middlename = "ter", Lastname = "Nas" },
                new Personnel { Id = 1, Firstname = "Co", Middlename = "", Lastname = "Mies" },
                new Personnel { Id = 1, Firstname = "Bas", Middlename = "", Lastname = "Sillen" }
            };

            context.Personnel.AddRange(personnel);
            context.SaveChanges();
        }
    }
}
