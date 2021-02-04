using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLS.Models;

namespace SLS
{
    public class SQLItemData : IItemData
    {
        private readonly SLSDbContext db;

        public SQLItemData(SLSDbContext db)
        {
            this.db = db;
        }

        public Item Add(Item newitem)
        {
            db.Add(newitem);
            return newitem;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Item Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                db.Item.Remove(item);
            }
            return item;
        }

        public Item GetById(int id)
        {
            return db.Item.Find(id);
        }


        public int GetCountOfItems()
        {
            return db.Customer.Count();
        }

        static int counter;
        public int GetOrderNumber()
        {
            return counter++;
        }


        public IEnumerable<Item> GetItemsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Item Update(Item updatedItem)
        {
            var entity = db.Item.Attach(updatedItem);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedItem;
        }
    }
}
