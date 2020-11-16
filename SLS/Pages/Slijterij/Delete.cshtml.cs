using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SLS;

namespace SLS.Pages.Slijterij
{
    public class DeleteModel : PageModel
    {
        private readonly IWhiskyData whiskyData;

        public Whisky Whisky { get; set; }


        public DeleteModel(IWhiskyData whiskyData)
        {
            this.whiskyData = whiskyData;
        }
        public IActionResult OnGet(int whiskyId)
        {
            Whisky = whiskyData.GetById(whiskyId);
            if (Whisky == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int whiskyId)
        {
            var whisky = whiskyData.Delete(whiskyId);
            whiskyData.Commit();

            if(whisky == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{whisky.Name} deleted";
            return RedirectToPage("./List");
        }

    }
}
