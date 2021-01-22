using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class IzmeniSebeModel : PageModel
    {
        public bool Ucitano { get; set; }
        public AppContext _db{get;set;}
        [BindProperty(SupportsGet=true)]

        public Prodavac prodavacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public int? idProdavac{get;set;}

        public IzmeniSebeModel(AppContext db)
        {
            _db=db;
            ErrorMessage="";
            Ucitano=false;
        }

        public async Task<ActionResult> OnGet()
        {

        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPostIzmeni()
        {
			
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

        }

    }
}
