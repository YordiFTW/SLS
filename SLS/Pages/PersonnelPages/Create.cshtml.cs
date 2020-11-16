using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SLS;

namespace SLS.Pages.PersonnelPages
{
    public class CreateModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public CreateModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Personnel Personnel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personnel.Add(Personnel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
