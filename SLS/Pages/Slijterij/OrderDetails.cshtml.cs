using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SLS;
using SLS.Models;

namespace SLS.Pages.CustomerPages
{
    public class OrderDetailsModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public OrderDetailsModel(SLS.SLSDbContext context)
        {
            _context = context;
        }
        public List<Item> MyOrder;
        public IEnumerable<Whisky> getWhiskies { get; set; }
        public IEnumerable<Item> getItems { get; set; }
        public IEnumerable<Customer> getCustomers { get; set; }

        public Item Item { get; set; }

        public Whisky Whisky { get; set; }
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
