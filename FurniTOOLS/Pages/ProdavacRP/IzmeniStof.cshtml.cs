using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.EntityFrameworkCore;
namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class IzmeniStofModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; }         
        public AppContext _db{get;set;}
        [BindProperty(SupportsGet=true)]
        public int idStof { get; set; }
        public int? idProdavac{get;set;}
        [BindProperty(SupportsGet=true)]
        public Stof stofZaIzmenu{get;set;}
        [BindProperty(SupportsGet=true)]
        public int stofZaIzmenuID { get; set; }
        [BindProperty(SupportsGet=true)]
        public TipStofa[] tipoviStofa{get;set;}
        [BindProperty(SupportsGet=true)]
        public TipStofa tipZaDodavanje{get;set;}
        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        [BindProperty]

        public string ErrorMessage3{get;set;}
        [BindProperty]

        public IFormFile SlikaStofa{get;set;}

        [BindProperty]
        public bool Ucitano{get;set;}
        [BindProperty]

        public bool PromeniSliku{get;set;}

        public IzmeniStofModel(AppContext db)
        {
            _db=db;
            ErrorMessage1="";
            ErrorMessage2="";
            ErrorMessage3="";
            PromeniSliku=false;
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet(int id)
        {

        }
        public async Task<ActionResult> OnPost(int id)
        {

        }
        public async Task<ActionResult> OnPostDodajAsync()
        {

        }
        public async Task<ActionResult> OnPostObrisiAsync(int idTip)
        {

        }
        public async Task<ActionResult> OnPostIzmeniAsync()
        {

        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

        }
    }
}

