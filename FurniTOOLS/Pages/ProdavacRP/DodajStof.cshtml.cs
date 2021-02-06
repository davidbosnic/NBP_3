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
    public class DodajStofModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; }         
        public bool Ucitano { get; set; }
        public AppContext _db{get;set;}

        public int? idProdavac{get;set;}

        [BindProperty]
        public IFormFile SlikaStofa{get;set;}

        [BindProperty(SupportsGet=true)]
        public Stof stofZaDodavanje{get;set;}

        [BindProperty]
        public TipStofa[] tipoviZaDodavanje{get;set;}

        [BindProperty(SupportsGet=true)]
        public int? brojTipova{get;set;}

        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        [BindProperty]
        public string ErrorMessage3{get;set;}


        public DodajStofModel(AppContext db)
        {
            _db=db;
            Ucitano=false;
            ErrorMessage1="";
            ErrorMessage2="";
            ErrorMessage3="";
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostPrimeniAsync()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostDodajAsync()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
