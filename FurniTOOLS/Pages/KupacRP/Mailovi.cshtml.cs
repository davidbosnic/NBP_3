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
    public class MailoviModel : PageModel
    {
        [BindProperty]
        public Kupac Ja { get; set; }        
        public string idKupac { get; set; }
        private readonly IMongoDatabase _db;
        public List<Narudzbina> Narudzbine { get; set; }
        public int? IzabraniID { get; set; }
        public MailoviModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Kupac>("Kupci");
                Ja = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();

                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                List<Narudzbina> pom = new List<Narudzbina>();
                if (Ja.MojeNarudzbine_ != null)
                {
                    foreach (MongoDBRef n in Ja.MojeNarudzbine_)
                    {
                        var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                        Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                        if (npom.Status != "Korpa")
                        {
                            npom.ProfilKorisnika_ = Ja;
                            pom.Add(npom);
                        }
                    }
                }
                Ja.MojeNarudzbine = pom;
                Narudzbine = pom;
                IzabraniID = null;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostObrisi(string id)
        {

             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Kupac>("Kupci");
                Kupac pom1 = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();

                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                Narudzbina pom = new Narudzbina();
                foreach (MongoDBRef n in pom1.MojeNarudzbine_)
                {
                    var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                    Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                    if (npom.ID == id.ToString())
                    {
                        pom = npom;
                    }
                }
                pom.Procitana = true;
                coll2.ReplaceOne(x => x.ID == id.ToString(),pom);
                IzabraniID = null;
                Console.WriteLine("U fji sam");
                return RedirectToPage();
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
