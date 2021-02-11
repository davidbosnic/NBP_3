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
        public string idKupac { get; set; }
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
            string idLog;
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
                    foreach (MongoDBRef n in Ja.MojeNarudzbine_.ToList())
                    {
                        var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                        Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                        
                        if (npom.Status == "Korpa")
                        {
                            pom.Add(npom);
                        }
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
        public async Task<IActionResult> OnPostIzbaci(string id)
        {
            var coll = _db.GetCollection<Kupac>("Kupci");

            
            Kupac p = coll.Find(x => x.ID == HttpContext.Session.GetString("idKupac")).SingleOrDefault();
            int index= p.MojeNarudzbine_.ToList().FindIndex(x => x.Id.AsString == id);
            List<MongoDBRef> pomm = p.MojeNarudzbine_.ToList();
            pomm.RemoveAt(index);
            p.MojeNarudzbine_ = pomm;
            coll.ReplaceOne(x => x.ID == HttpContext.Session.GetString("idKupac"), p);


            var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");

            //verovatno ce onda treba i dbref koji kupac cuva da se brise, trebe se proveri
            coll2.DeleteOne(x => x.ID == id.ToString());
            


            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostKupi()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Kupac>("Kupci");
                Kupac pom1 = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();
                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");

                var coll3 = _db.GetCollection<Prodavac>("Prodavci");
                
                if (pom1.MojeNarudzbine_ != null)
                {
                    foreach (MongoDBRef n in pom1.MojeNarudzbine_.ToList())
                    {
                        var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                        Narudzbina npom = coll2.Find(filter).SingleOrDefault();

                        if (npom.Status == "Korpa")
                        {
                            Prodavac pommm = coll3.Find(x => x.ID == npom.NarucenProizvod_.MojProdavac.Id.AsString).SingleOrDefault();
                            npom.Status = "Narucen";
                            if (pommm.MojeNarudzbine==null)
                            {
                                pommm.MojeNarudzbine = new List<MongoDBRef>();
                            }
                            pommm.MojeNarudzbine.Add(new MongoDBRef("mojenarudzbine", npom.ID));
                            coll3.ReplaceOne(x => x.ID == pommm.ID, pommm);
                            coll2.ReplaceOne(x => x.ID == npom.ID, npom);
                        }
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
    }
}
