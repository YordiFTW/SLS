using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLS
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetCustomersByName(string name);
        Customer GetById(int id);
        Customer Update(Customer updatedCustomer);
        Customer Add(Customer newCustomer);
        Customer Delete(int id);
        int GetCountOfCustomer();
        int Commit();
    }
}
