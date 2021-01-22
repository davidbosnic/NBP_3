using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class ProdavacHomePageModel : PageModel
    {
        public AppContext _db {get;set;}
        [BindProperty]
        public Prodavac Ja { get; set; } 
        int? idProdavac {get;set;}
        public ProdavacHomePageModel(AppContext db)
        {
            _db=db;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {

        }
        public async Task<ActionResult> OnPostIzloguj()
        {

        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

        }
    }
}
