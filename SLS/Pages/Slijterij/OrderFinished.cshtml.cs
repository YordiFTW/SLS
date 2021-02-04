using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.VisualBasic.CompilerServices;
using SLS.Models;
using Microsoft.EntityFrameworkCore;

namespace SLS.Pages.Slijterij
{
    public class OrderFinishedModel : PageModel
    {
        private SLSDbContext db;
        public List<Item> MyOrder;
        public decimal Total = 0;
        [BindProperty]
        public Customer customer { get; set; }
        
        public Item item { get; set; }

        public Whisky whisky { get; set; }

        public OrderFinishedModel(SLSDbContext _db)
        {
            db = _db;
        }

        public void OnGet(int id)
        {

            MyOrder = WhiskySessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "order");
            Total = MyOrder.Sum(item => item.Whisky.Price * item.Quantity);
        }

        public IActionResult OnGetDelete(int id)
        {
            var order = WhiskySessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "order");
            var index = Exists(order, id);
            order.RemoveAt(index);
            WhiskySessionHelper.SetObjectAsJson(HttpContext.Session, "order", order);
            return RedirectToPage("Order");
        }

        public IActionResult OnGetBuy(int id)
        {

            var whisky = db.Whiskies.Find(id);
            var order = WhiskySessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "order");
            if (order == null)
            {
                order = new List<Item>();
                order.Add(new Item() { 
                        Whisky = whisky,
                        Quantity = 1,
                });
                WhiskySessionHelper.SetObjectAsJson(HttpContext.Session, "order", order);
            }
            else
            {
                var index = Exists(order, id);
                if(index == -1)
                {
                    order.Add(new Item()
                    {
                        Whisky = whisky,
                        Quantity = 1,
                    });
                }
                else
                {
                    var newQuantity = order[index].Quantity + 1;
                    order[index].Quantity = newQuantity;
                }
                WhiskySessionHelper.SetObjectAsJson(HttpContext.Session, "order", order);
            }

           
            return RedirectToPage("Order");
        }

        private int Exists(List<Item> order, int id)
        {
            for(int i = 0; i < order.Count; i++)
            {
                if (order[i].Whisky.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var order = WhiskySessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "order");


            foreach (Item item in order)
            {
                item.Whisky = db.Whiskies.Find(item.Whisky.Id);

                db.Item.Add(item);
            }
            

            db.Customer.Add(customer);

            await db.SaveChangesAsync();

            return RedirectToPage("./OrderIndex");
        }
    }
}
