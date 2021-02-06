using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class KupacPromenaSifreModel : PageModel
    {
        // [BindProperty]
        // public Kupac Ja { get; set; }
       public bool Ucitano { get; set; }
        public AppContext _db{get;set;}
        [BindProperty(SupportsGet=true)]

        public Kupac kupacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public int? idKupac{get;set;}

        [BindProperty]
        public string novaSifra{get;set;}

        [BindProperty]
        public string novaSifraPonovo{get;set;}

        [BindProperty]
        public string staraSifra{get;set;}
        


        public KupacPromenaSifreModel(AppContext db)
        {
            _db=db;
            ErrorMessage="";
            Ucitano=false;
        }

        public async Task<ActionResult> OnGet()
        {
            return Page();
        }

        public async Task<ActionResult> OnPostIzmeni()
        {
            return Page();
        }
        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }

    }
}