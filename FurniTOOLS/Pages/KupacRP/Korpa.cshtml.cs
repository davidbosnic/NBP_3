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
    public class KorpaModel : PageModel
    {
        [BindProperty]
        public Kupac Ja { get; set; }
        public List<Narudzbina> narudzbine { get; set; }
        public int? idKupac { get; set; }
        private readonly IMongoDatabase _db;
        public KorpaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
        }

        public double ukupno()
        {
            double ukupno=0;
            foreach (var item in narudzbine)
            {
                ukupno+=item.CenaBato();
            }
            return ukupno;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idKupac"), out idLog);
            if (log)
            {
                idKupac = idLog;
                var coll = _db.GetCollection<Kupac>("Kupci");
                Ja = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();
                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                List<Narudzbina> pom = new List<Narudzbina>();
                foreach (MongoDBRef n in Ja.MojeNarudzbine_)
                {
                    var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                    Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                    if (npom.Status == "Korpa")
                    {
                        pom.Add(npom);
                    }
                }
                Ja.MojeNarudzbine = pom;
                narudzbine = pom;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostIzbaci(int id)
        {
            var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
            //verovatno ce onda treba i dbref koji kupac cuva da se brise, trebe se proveri
            coll2.DeleteOne(x => x.ID == id.ToString());
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostKupi()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idKupac"), out idLog);
            if (log)
            {
                idKupac = idLog;
                var coll = _db.GetCollection<Kupac>("Kupci");
                Kupac pom1 = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();
                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                
                foreach (MongoDBRef n in pom1.MojeNarudzbine_)
                {
                    var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                    Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                    if (npom.Status == "Korpa")
                    {
                        npom.Status = "Narucen";
                        coll2.ReplaceOne(x => x.ID == npom.ID, npom);
                    }
                }

                return RedirectToPage();
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
