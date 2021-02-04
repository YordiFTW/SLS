using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLS
{
    public class SQLCustomerData : ICustomerData
    {
        private readonly SLSDbContext db;

        public SQLCustomerData(SLSDbContext db)
        {
            this.db = db;
        }

        public Customer Add(Customer newCustomer)
        {
            db.Add(newCustomer);
            return newCustomer;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Customer Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                db.Customer.Remove(customer);
            }
            return customer;
        }

        public Customer GetById(int id)
        {
            return db.Customer.Find(id);
        }



        public int GetCountOfCustomer()
        {
            return db.Customer.Count();
        }

        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            var query = from r in db.Customer
                        where r.Firstname.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Firstname
                        select r;
            return query;
        }

        public Customer Update(Customer updatedCustomer)
        {
            var entity = db.Customer.Attach(updatedCustomer);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedCustomer;
        }
    }
}
