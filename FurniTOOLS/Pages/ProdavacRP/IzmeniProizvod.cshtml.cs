using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;
using static System.Net.Mime.MediaTypeNames;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class IzmeniProizvodModel : PageModel
    {
        [BindProperty]
        public int idProizvod { get; set; }
        public bool Ucitano { get; set; }
        public AppContext _db{get;set;}
        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        public int? idProdavac{get;set;}

        [BindProperty(SupportsGet=true)]
        public Proizvod proizvodZaIzmenu{get;set;}

        [BindProperty]
        public IFormFile Slika {get;set;}

        [BindProperty]
        public bool PromeniSliku{get;set;}
        [BindProperty]
        public Prodavac Ja { get; set; } 
        public IzmeniProizvodModel(AppContext db)
        {
            _db=db;
            ErrorMessage1="";
            ErrorMessage2="";
            PromeniSliku=false;
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPost(int id)
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzmeni()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
