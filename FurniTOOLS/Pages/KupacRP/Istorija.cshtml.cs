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
    public class IstorijaModel : PageModel
    {
        [BindProperty]
        public Kupac Ja { get; set; }        
        public PaginatedList<Narudzbina> narudzbine { get; set; }
        public string idKupac { get; set; }
        private readonly IMongoDatabase _db;

        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}
        public IstorijaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            pageInput =1;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet(int? pageIndex)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Kupac>("Kupci");
                Ja = coll.Find(x => x.ID == idKupac.ToString()).SingleOrDefault();

                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                List<Narudzbina> pom=new List<Narudzbina>();
                if (Ja.MojeNarudzbine_ != null)
                {


                    foreach (MongoDBRef n in Ja.MojeNarudzbine_)
                    {
                        var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                        Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                        if (npom.Status != "Korpa")
                        {
                            pom.Add(npom);
                        }
                    }
                }
                Ja.MojeNarudzbine = pom;

                IQueryable<Narudzbina> narudzbineIQ = pom.AsQueryable();
                pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                narudzbine = await PaginatedList<Narudzbina>.CreateAsync(
                     narudzbineIQ, pageIndex ?? 1, pageSize);

                //narudzbine=_db.Narudzbine.Include(x=>x.NarucenProizvod_.MojProdavac_).Include(x=>x.NarucenStof_.MojiStof_).Where(x=>x.ProfilKorisnika_.ID==idKupac && x.Status!="Korpa").ToList(); 
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIdiNaStranu()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                Console.WriteLine(pageInput + "++++++++++");
                return RedirectToPage("./Istorija", new { pageIndex = pageInput });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                HttpContext.Session.SetString("pageSize", brEl.ToString());
                return RedirectToPage("./Istorija", new { pageIndex = 1 });
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
