using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SLS;

namespace SLS.Pages.Slijterij
{
    public class EditModel : PageModel
    {
        private readonly IWhiskyData whiskyData;
        private readonly IHtmlHelper htmlHelper;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SLS.SLSDbContext _context;

        [BindProperty]
        public Whisky Whisky { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public string Message { get; set; }

        public List<string> Locations { get; set; }

        public string SearchLocation { get; set; }

        public IEnumerable<SelectListItem> Type { get; set; }

        public EditModel(IWhiskyData whiskyData,
                         IHtmlHelper htmlHelper,
                         IWebHostEnvironment webHostEnvironment,
                         SLS.SLSDbContext _context)
        {
            this.whiskyData = whiskyData;
            this.htmlHelper = htmlHelper;
            this.webHostEnvironment = webHostEnvironment;
            this._context = _context;
        }
        public async Task OnGetAsync(int? whiskyId, string SearchLocation)
        {
            Type = htmlHelper.GetEnumSelectList<WhiskyType>();
            if(whiskyId.HasValue)
            {
                Message = "Aanpassen";
                Whisky = whiskyData.GetById(whiskyId.Value);
            }
            else
            {
                Message = "Whisky Toevoegen";
                Whisky = new Whisky();
                
            }

            IQueryable<string> locationQuery = from m in _context.Whiskies
                                               orderby m.Location
                                               select m.Location;

            var whiskies = from m in _context.Whiskies
                           select m;

            Locations = new List<string>(await locationQuery.Distinct().ToListAsync());

            if (Whisky == null)
            {
                RedirectToPage("./NotFound");
            }
            Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Type = htmlHelper.GetEnumSelectList<WhiskyType>();
                return Page();
            }

            if (Photo != null)
            {
                if(Whisky.PhotoPath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                        "images", Whisky.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                Whisky.PhotoPath = ProcessUploadedFile();
            }

            if(Whisky.Id > 0)
            {
                whiskyData.Update(Whisky);
            }
            else
            {
                whiskyData.Add(Whisky);
            }
            whiskyData.Commit();
            TempData["Message"] = "Whisky Saved!";
            return RedirectToPage("./Detail", new { whiskyId = Whisky.Id });
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
