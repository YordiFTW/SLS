using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SLS.Pages.Slijterij
{
    public class DetailModel : PageModel
    {
        private readonly IWhiskyData whiskyData;
        [TempData]
        public string Message { get; set; }
        public Whisky Whisky { get; set; }

        public DetailModel(IWhiskyData whiskyData)
        {
            this.whiskyData = whiskyData;
        }

        public IActionResult OnGet(int whiskyId)
        {
            Whisky = whiskyData.GetById(whiskyId);
            if(Whisky == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
