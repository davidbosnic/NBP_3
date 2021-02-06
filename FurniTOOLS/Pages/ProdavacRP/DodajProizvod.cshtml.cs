using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class DodajProizvodModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; } 
        public bool Ucitano { get; set; }
        public AppContext _db{get;set;}
        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        [BindProperty]
        public int? idProdavac{get;set;}

        [BindProperty(SupportsGet=true)]
        public Proizvod noviProizvod{get;set;}
        [BindProperty(SupportsGet=true)]
        public string nebitno { get; set; }

        [BindProperty]
        public IFormFile Slika {get;set;}

        public DodajProizvodModel(AppContext db)
        {
            _db=db;
            ErrorMessage1="";
            ErrorMessage2="";
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostDodaj()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
