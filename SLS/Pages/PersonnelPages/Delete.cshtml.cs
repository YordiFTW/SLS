using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SLS;

namespace SLS.Pages.PersonnelPages
{
    public class DeleteModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public DeleteModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personnel Personnel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.Id == id);

            if (Personnel == null)
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

            Personnel = await _context.Personnel.FindAsync(id);

            if (Personnel != null)
            {
                _context.Personnel.Remove(Personnel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
