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
    public class MojiStofoviModel : PageModel
    {
        private readonly IMongoDatabase _db;

        public PaginatedList<Stof> MojiStofovi { get; set; }
        public string idProdavac { get; set; }
        public MojiStofoviModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            pageInput = 1;
        }
        [BindProperty]
        public Prodavac Ja { get; set; }         
        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet(int? pageIndex)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");

                Ja = coll.Find(x=>x.ID== idProdavac.ToString()).FirstOrDefault();
                if (Ja.MojiStofovi != null)
                {
                    IQueryable<Stof> stofIQ = Ja.MojiStofovi.AsQueryable();
                    pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                    MojiStofovi = await PaginatedList<Stof>.CreateAsync(
                         stofIQ, pageIndex ?? 1, pageSize);
                }
                else
                {
                    MojiStofovi = await PaginatedList<Stof>.CreateAsync(
                         new List<Stof>().AsQueryable(), pageIndex ?? 1, pageSize);
                }
                //MojiProizvodi=_db.Proizvodi.Where(x=>x.MojProdavac_.ID==idProdavac).ToList();
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
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                Console.WriteLine(pageInput + "++++++++++");
                return RedirectToPage("./MojiStofovi", new { pageIndex = pageInput });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                HttpContext.Session.SetString("pageSize", brEl.ToString());
                return RedirectToPage("./MojiStofovi", new { pageIndex = 1 });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostObrisiAsync(string naziv)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                //ovde isto ce po imenu verovatno, ako ne uvedemo neki brojac ili slicno za id
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idProdavac.ToString()).SingleOrDefault();
                pom.MojiStofovi.RemoveAll(x => x.Naziv == naziv);
                coll.ReplaceOne(x => x.ID == idProdavac.ToString(), pom);
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
