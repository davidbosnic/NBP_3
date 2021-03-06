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
    public class KupacPromenaSifreModel : PageModel
    {
        
       public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty(SupportsGet=true)]

        public Kupac kupacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public string idKupac{get;set;}

        [BindProperty]
        public string novaSifra{get;set;}

        [BindProperty]
        public string novaSifraPonovo{get;set;}

        [BindProperty]
        public string staraSifra{get;set;}
        


        public KupacPromenaSifreModel(IDatabaseSettings settings)
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

        public async Task<ActionResult> OnPostIzmeni()
        {
            Ucitano = true;
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Kupac>("Kupci");
                Kupac pom = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();


                if (pom.Sifra != staraSifra)
                {
                    ErrorMessage = "Pogre�ili ste trenutnu �ifru";
                    return Page();
                }
                if (novaSifra != novaSifraPonovo)
                {
                    ErrorMessage = "Niste uneli dva puta istu �ifru";
                    return Page();
                }
                else
                {
                    ErrorMessage = "";
                    pom.Sifra = novaSifra;
                    coll.ReplaceOne(x => x.ID == idKupac.ToString(), pom);
      
                    return RedirectToPage("./KupacHomePage");
                }


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