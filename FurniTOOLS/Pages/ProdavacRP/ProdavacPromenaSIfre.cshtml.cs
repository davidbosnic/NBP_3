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
    public class ProdavacPromenaSifreModel : PageModel
    {
        public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty(SupportsGet=true)]

        public Prodavac prodavacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public string idProdavac{get;set;}

        [BindProperty]
        public string novaSifra{get;set;}

        [BindProperty]
        public string novaSifraPonovo{get;set;}

        [BindProperty]
        public string staraSifra{get;set;}
        


        public ProdavacPromenaSifreModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }

        public async Task<ActionResult> OnGet()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                //Ja=_db.Prodavci.Where(x=>x.ID==idProdavac).SingleOrDefault();
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                prodavacZaIzmenu = coll.Find(x => x.ID == idProdavac.ToString()).SingleOrDefault();
                Console.WriteLine(prodavacZaIzmenu.Ime);
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
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x => x.ID == idProdavac.ToString()).SingleOrDefault();
                if (pom.Sifra != staraSifra)
                {
                    ErrorMessage = "Pogrešili ste trenutnu šifru";
                    return Page();
                }
                if (novaSifra != novaSifraPonovo)
                {
                    ErrorMessage = "Niste uneli dva puta istu šifru";
                    return Page();
                }
                else
                {
                    ErrorMessage = "";
                    pom.Sifra = novaSifra;
                    coll.ReplaceOne(x => x.ID == idProdavac.ToString(), pom);
                    return RedirectToPage("./ProdavacHomePage");
                }


            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            string idLog;
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