using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;


namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class DodajProizvodModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; } 
        public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        [BindProperty]
        public string idProdavac{get;set;}

        [BindProperty(SupportsGet=true)]
        public Proizvod noviProizvod{get;set;}
        [BindProperty(SupportsGet=true)]
        public string nebitno { get; set; }

       

        public DodajProizvodModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage1 ="";
            ErrorMessage2="";
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Ja = coll.Find(x=>x.ID==idProdavac.ToString()).SingleOrDefault();
                
                
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostDodaj()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idProdavac.ToString()).FirstOrDefault();
                if (pom.MojiProizvodi==null)
                {
                    pom.MojiProizvodi = new List<Proizvod>();
                }
                noviProizvod.MojProdavac = new MongoDBRef("mojprodavac", idProdavac.ToString());
                pom.MojiProizvodi.Add(noviProizvod);


                ErrorMessage1 = "";
                ErrorMessage2 = "";

                coll.ReplaceOne(x => x.ID == idProdavac.ToString(), pom);
                return RedirectToPage("./ProdavacHomePage");
           
            }
            return RedirectToPage("../Index");
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                HttpContext.Session.Remove("idProdavac");
                HttpContext.Session.Remove("imeProdavca");
                HttpContext.Session.Remove("prezimeProdavca");
                HttpContext.Session.Remove("emailProdavca");
            }
            return RedirectToPage("../Index");
        }
    }
}
