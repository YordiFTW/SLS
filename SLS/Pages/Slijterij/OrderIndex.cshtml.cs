using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SLS;
using SLS.Models;

namespace SLS.Pages.Slijterij
{
    public class OrderIndexModel : PageModel
    {
        private readonly SLS.SLSDbContext _context;

        public OrderIndexModel(SLS.SLSDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public IList<Whisky> Whisky { get; set; }

        public async Task OnGetAsync()
        {
            
            //Item = await _context.Item.ToListAsync();
            Item = await _context.Item.ToListAsync();
            Whisky = await _context.Whiskies.ToListAsync();
        }
    }
}
