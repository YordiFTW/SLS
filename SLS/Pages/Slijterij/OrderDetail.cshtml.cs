using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SLS.Models;

namespace SLS.Pages.Slijterij
{
    public class OrderDetailModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;
        
        public Item Item { get; set; }

        public OrderDetailModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
