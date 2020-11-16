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
    public class IndexModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public IndexModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        public IList<Whisky> Whisky { get;set; }

        public async Task OnGetAsync()
        {
            Whisky = await _context.Whiskies.ToListAsync();
        }


    }
}
