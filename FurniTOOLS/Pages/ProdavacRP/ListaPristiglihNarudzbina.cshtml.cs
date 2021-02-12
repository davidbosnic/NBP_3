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
    public class ListaPristiglihNarudzbinaModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; }
        public PaginatedList<Narudzbina> narudzbine { get; set; }
        public string idProdavac { get; set; }
        private readonly IMongoDatabase _db;

        [BindProperty]
        public int pageInput { get; set; }

        [BindProperty]

        public int pageSize { get; set; }
        public ListaPristiglihNarudzbinaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            pageInput = 1;
        }


        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet(int? pageIndex)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Ja = coll.Find(x => x.ID == idProdavac.ToString()).SingleOrDefault();

                var coll2 = _db.GetCollection<Narudzbina>("Narudzbine");
                List<Narudzbina> pom = new List<Narudzbina>();
                if (Ja.MojeNarudzbine != null)
                {
                    foreach (MongoDBRef n in Ja.MojeNarudzbine)
                    {
                        var filter = Builders<Narudzbina>.Filter.Eq(e => e.ID, n.Id.AsString);
                        Narudzbina npom = coll2.Find(filter).SingleOrDefault();
                        pom.Add(npom);
                    }
                }
                Ja.MojeNarudzbine_ = pom;

                IQueryable<Narudzbina> narudzbineIQ = pom.AsQueryable();
                pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                narudzbine = await PaginatedList<Narudzbina>.CreateAsync(
                     narudzbineIQ, pageIndex ?? 1, pageSize);

                
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIdiNaStranu()
        {
             
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
