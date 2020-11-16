using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SLS;

namespace SLS.Pages.Slijterij
{
    public class SoftDeletedModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWhiskyData whiskyData;
        private readonly SLS.SLSDbContext _context;

        public IEnumerable<Whisky> Whiskies { get; set; }

        public SelectList Locations { get; set; }
        public string SearchLocation { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public SelectList AlcoholPercentages { get; set; }
        public string SearchAlcoholPercentage { get; set; }

        public SelectList Types { get; set; }

        public WhiskyType SearchType { get; set; }

        public SelectList Ages { get; set; }
        public string SearchAge { get; set; }


        public SoftDeletedModel(IConfiguration config,
                         IWhiskyData whiskyData,
                         SLS.SLSDbContext _context)
        {
            this.config = config;
            this.whiskyData = whiskyData;
            this._context = _context;

        }

        public async Task OnGetAsync(string SearchLocation, string SearchTerm, string SearchAlcoholPercentage,
                                        string SearchAge, WhiskyType SearchType)
        {
            IQueryable<string> locationQuery = from m in _context.Whiskies
                                               orderby m.Location
                                               select m.Location;

            IQueryable<string> alcoholQuery = from a in _context.Whiskies
                                              orderby a.AlcoholPercentage
                                              select a.AlcoholPercentage.ToString();

            IQueryable<string> ageQuery = from g in _context.Whiskies
                                          orderby g.Age
                                          select g.Age.ToString();

            IQueryable<string> typeQuery = from t in _context.Whiskies
                                           orderby t.Type
                                           select t.Type.ToString();

            var whiskies = from m in _context.Whiskies
                           select m;

            if (!String.IsNullOrEmpty(SearchLocation))
            {
                whiskies = whiskies.Where(x => x.Location == SearchLocation);
            }

            if (!String.IsNullOrEmpty(SearchTerm))
            {
                whiskies = whiskies.Where(s => s.Name.Contains(SearchTerm));
            }

            if (!String.IsNullOrEmpty(SearchAlcoholPercentage))
            {
                whiskies = whiskies.Where(x => x.AlcoholPercentage.ToString() == SearchAlcoholPercentage);
            }

            if (!String.IsNullOrEmpty(SearchAge))
            {
                whiskies = whiskies.Where(x => x.Age.ToString() == SearchAge);
            }

            if (!String.IsNullOrEmpty(SearchType.ToString()))
            {
                if (!(SearchType == WhiskyType.none))
                {
                    whiskies = whiskies.Where(x => x.Type == SearchType);
                }

            }

            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            Ages = new SelectList(await ageQuery.Distinct().ToListAsync());
            AlcoholPercentages = new SelectList(await alcoholQuery.Distinct().ToListAsync());
            Locations = new SelectList(await locationQuery.Distinct().ToListAsync());

            Whiskies = await whiskies.Where(x => x.IsDeleted == true).ToListAsync();
        }
    }
}
