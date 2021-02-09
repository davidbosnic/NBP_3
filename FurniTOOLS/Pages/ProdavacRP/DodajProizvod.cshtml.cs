using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;

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
        public int? idProdavac{get;set;}

        [BindProperty(SupportsGet=true)]
        public Proizvod noviProizvod{get;set;}
        [BindProperty(SupportsGet=true)]
        public string nebitno { get; set; }

        //[BindProperty]
        //public IFormFile Slika {get;set;}

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
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Ja = coll.Find(x=>x.ID==idProdavac.ToString()).SingleOrDefault();
                
                //noviProizvod.MojProdavac= new MongoDBRef("mojprodavac", idProdavac.ToString());
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostDodaj()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {

                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();

                noviProizvod.MojProdavac = new MongoDBRef("mojprodavac", idLog.ToString());
                pom.MojiProizvodi.Add(noviProizvod);


                ErrorMessage1 = "";
                ErrorMessage2 = "";

                coll.ReplaceOne(x => x.ID == idLog.ToString(), pom);
                return RedirectToPage("./ProdavacHomePage");
           
            }
            return RedirectToPage("../Index");
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
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
