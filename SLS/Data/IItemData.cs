using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLS.Models;

namespace SLS
{
    public interface IItemData
    {
        Item GetById(int id);
        Item Update(Item updatedItem);
        Item Add(Item newItem);
        Item Delete(int id);
        int GetCountOfItems();
        int Commit();

        int GetOrderNumber();
    }
}
