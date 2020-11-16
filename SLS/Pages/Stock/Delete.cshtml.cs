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
    public class DeleteModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public DeleteModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Whisky = await _context.Whiskies.FindAsync(id);

            if (Whisky != null)
            {
                _context.Whiskies.Remove(Whisky);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
