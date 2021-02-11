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
    public class PrikazNarudzbineModel : PageModel
    {
        private readonly IMongoDatabase _db;
        [BindProperty]
        public Narudzbina Narudzbina { get; set; }
        [BindProperty]
        public Prodavac Ja { get; set; }

        public PrikazNarudzbineModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
        }


        public async Task<IActionResult> OnPost(string id)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Ja = coll.Find(x => x.ID == HttpContext.Session.GetString("idProdavac")).SingleOrDefault();

                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                Narudzbina = coll2.Find(x => x.ID == id).SingleOrDefault();

                var coll3 = _db.GetCollection<Kupac>("Kupci");

                Narudzbina.ProfilKorisnika_ = coll3.Find(x => x.ID == Narudzbina.ProfilKorisnika.Id.AsString).SingleOrDefault();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostPrihvati()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                
                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                Narudzbina pom = coll2.Find(x => x.ID == Narudzbina.ID).SingleOrDefault();
                pom.Status = "Potvrdjeno";
                coll2.ReplaceOne(x => x.ID == pom.ID, pom);
                return RedirectToPage("./ListaPristiglihNarudzbina");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostOdbij()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                Narudzbina pom = coll2.Find(x => x.ID == Narudzbina.ID).SingleOrDefault();
                pom.Status = "Odbijeno";
                coll2.ReplaceOne(x => x.ID == pom.ID, pom);
                return RedirectToPage("./ListaPristiglihNarudzbina");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostIsporuceno()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                Narudzbina pom = coll2.Find(x => x.ID == Narudzbina.ID).SingleOrDefault();
                pom.Status = "Isporuceno";
                coll2.ReplaceOne(x => x.ID == pom.ID, pom);
                return RedirectToPage("./ListaPristiglihNarudzbina");
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostIzlogujSe()
        {
            string idLog;
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





        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
    }
}
