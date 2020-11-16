using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SLS;

namespace SLS.Pages.Stock
{
    public class EditModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public EditModel(SLS.SLSDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Whisky).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhiskyExists(Whisky.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WhiskyExists(int id)
        {
            return _context.Whiskies.Any(e => e.Id == id);
        }
    }
}
