using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLS
{
    public class InMemoryWhiskyData : IWhiskyData
    {
        private readonly List<Whisky> whiskies;

        public InMemoryWhiskyData()
        {
            whiskies = new List<Whisky>()
            {
                new Whisky { Id = 1, Name = "Jack Daniels", Age = 1990, Location = "Speyside", AlcoholPercentage = 40, Type = WhiskyType.Blended},
                new Whisky { Id = 2, Name = "Speyburn", Age = 1995, Location = "Amsterdam", AlcoholPercentage = 60, Type = WhiskyType.singleGrain},
                new Whisky { Id = 3, Name = "Glen Moray", Age = 2000, Location = "London", AlcoholPercentage = 80, Type = WhiskyType.Vintage}
            };

        }

        public Whisky Add(Whisky newWhisky)
        {
            whiskies.Add(newWhisky);
            newWhisky.Id = whiskies.Max(r => r.Id) + 1;
            return newWhisky;
        }

        public int Commit()
        {
            return 0;
        }

        public Whisky Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Whisky ReverseDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Whisky GetById(int id)
        {
            return whiskies.SingleOrDefault(restaurants => restaurants.Id == id);
        }

        public int GetCountOfWhisky()
        {
            return whiskies.Count();
        }

        public IEnumerable<Whisky> GetWhiskiesByName(string name)
        {
            return from r in whiskies
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Whisky Update(Whisky updatedWhisky)
        {
            var whisky = whiskies.SingleOrDefault(r => r.Id == updatedWhisky.Id);
            if (whisky != null)
            {
                whisky.Name = updatedWhisky.Name;
                whisky.Age = updatedWhisky.Age;
                whisky.Location = updatedWhisky.Location;
                whisky.AlcoholPercentage = updatedWhisky.AlcoholPercentage;
                whisky.Type = updatedWhisky.Type;
                whisky.Price = updatedWhisky.Price;
                whisky.PhotoPath = updatedWhisky.PhotoPath;
                
            }
            return whisky;
        }
    }
}
