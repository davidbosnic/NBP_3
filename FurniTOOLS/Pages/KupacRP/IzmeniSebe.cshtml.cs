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
        // [BindProperty]
        // public Kupac Ja { get; set; }
       public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty(SupportsGet=true)]

        public Kupac kupacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public int? idKupac{get;set;}


        public IzmeniSebeModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
            Ucitano=false;
        }
        public async Task<ActionResult> OnGet()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idKupac"), out idLog);
            if (log)
            {
                idKupac = idLog;
                var coll = _db.GetCollection<Kupac>("Kupci");
                kupacZaIzmenu = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();
                //Ja=_db.Kupci.Where(x=>x.ID==idKupac).SingleOrDefault();
 
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
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idKupac"), out idLog);
            if (log)
            {
                idKupac = idLog;
                
                        ErrorMessage = "";
                //potencijalno se mozda ne sacuvaju dbref i ostale liste u kupac za izmenu nakon sto se aktivira ova post metoda
                var coll = _db.GetCollection<Kupac>("Kupci");
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
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idKupac"), out idLog);
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
