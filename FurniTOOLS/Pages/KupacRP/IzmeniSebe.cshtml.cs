using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class IzmeniSebeModel : PageModel
    {
        
       public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty(SupportsGet=true)]

        public Kupac kupacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public string idKupac{get;set;}


        public IzmeniSebeModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
            Ucitano=false;
        }
        public async Task<ActionResult> OnGet()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Kupac>("Kupci");
                kupacZaIzmenu = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();
                
 
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPostIzmeni()
        {
            Ucitano = true;
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                
                        ErrorMessage = "";
                
                var coll = _db.GetCollection<Kupac>("Kupci");
                Kupac pom = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();
                kupacZaIzmenu.MojeNarudzbine_ = pom.MojeNarudzbine_;
                coll.ReplaceOne(x => x.ID == idKupac.ToString(), kupacZaIzmenu);
                        HttpContext.Session.SetString("imeKupca", kupacZaIzmenu.Ime);
                        HttpContext.Session.SetString("prezimeKupca", kupacZaIzmenu.Prezime);
                        HttpContext.Session.SetString("emailKupca", kupacZaIzmenu.Email);
                        return RedirectToPage("./KupacHomePage");
              

            }
            else
            {
                return RedirectToPage("../Index");
            }

        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                HttpContext.Session.Remove("idKupac");
                HttpContext.Session.Remove("imeKupca");
                HttpContext.Session.Remove("prezimeKupca");
                HttpContext.Session.Remove("emailKupca");
            }
            return RedirectToPage("../Index");
        }

    }
}
