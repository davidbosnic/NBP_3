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
    public class KupacHomePageModel : PageModel
    {
        [BindProperty]
        public int Isporuceno { get; set; }
        [BindProperty]
        public int Naruceno { get; set; }
        [BindProperty]
        public int Korpa { get; set; }
        [BindProperty]
        public int Potvrdjeno { get; set; }
        [BindProperty]
        public int Odbijeno { get; set; }
        [BindProperty]
        public Kupac Ja { get; set; }
        public List<Narudzbina> narudzbine { get; set; }
        public int? idKupac { get; set; }
        private readonly IMongoDatabase _db;
        public KupacHomePageModel(IDatabaseSettings settings)
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
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idKupac"), out idLog);
            if (log)
            {
                idKupac = idLog;
                var coll = _db.GetCollection<Kupac>("Kupci");
                Ja = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();

                Korpa = 0;
                Naruceno = 0;
                Potvrdjeno = 0;
                Isporuceno = 0;
                Odbijeno = 0;

                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                List<Narudzbina> pom = new List<Narudzbina>();
                foreach (MongoDBRef n in Ja.MojeNarudzbine_)
                {
                    var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                    Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                    pom.Add(npom);
                    if (npom.Status=="Korpa")
                    {
                        Korpa++;
                    }
                    else if (npom.Status=="Naruceno")
                    {
                        Naruceno++;
                    }
                    else if (npom.Status=="Isporuceno")
                    {
                        Isporuceno++;
                    }
                    else if (npom.Status=="Potvrdjeno")
                    {
                        Potvrdjeno++;
                    }
                    else if (npom.Status=="Odbijeno")
                    {
                        Odbijeno++;
                    }
                    
                }
                Ja.MojeNarudzbine = pom;
                
                return Page();
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
