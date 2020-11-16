using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLS;

namespace SLS
{
    public class SQLWhiskyData : IWhiskyData
    {
        private readonly SLSDbContext db;

        public SQLWhiskyData(SLSDbContext db)
        {
            this.db = db;
        }

        public Whisky Add(Whisky newWhisky)
        {
            db.Add(newWhisky);
            return newWhisky;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Whisky Delete(int id)
        {
            var whisky = GetById(id);
            if (whisky != null)
            {
                whisky.GetType().GetProperty("IsDeleted").SetValue(whisky, true);
            }
            return whisky;
        }

        public Whisky ReverseDelete(int id)
        {
            var whisky = GetById(id);
            if (whisky != null)
            {
                whisky.GetType().GetProperty("IsDeleted").SetValue(whisky, false);
            }
            return whisky;
        }

        public Whisky GetById(int id)
        {
            return db.Whiskies.Find(id);
        }

        public int GetCountOfWhisky()
        {
            return db.Whiskies.Count();
        }

        public IEnumerable<Whisky> GetWhiskiesByName(string name)
        {
            var query = from r in db.Whiskies
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Whisky Update(Whisky updatedWhisky)
        {
            var entity = db.Whiskies.Attach(updatedWhisky);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedWhisky;
        }
    }
}
