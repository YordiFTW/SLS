using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SLS;

namespace SLS.Pages.Stock
{
    public class DetailsModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public DetailsModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        public Whisky Whisky { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Whisky = await _context.Whiskies.FirstOrDefaultAsync(m => m.Id == id);

            if (Whisky == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
