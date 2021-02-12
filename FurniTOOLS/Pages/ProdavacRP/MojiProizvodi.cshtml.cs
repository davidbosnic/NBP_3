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
    public class MojiProizvodiModel : PageModel
    {
        private readonly IMongoDatabase _db;
        public string idProdavac{get;set;}
        [BindProperty]
        public Prodavac Ja { get; set; } 
        public PaginatedList<Proizvod> MojiProizvodi {get;set;}
        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}

        public MojiProizvodiModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            pageInput =1;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet(int? pageIndex)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");

                Ja = coll.Find(x=>x.ID== idProdavac.ToString()).FirstOrDefault();
                if (Ja.MojiProizvodi != null)
                {
                    IQueryable<Proizvod> proizvodIQ = Ja.MojiProizvodi.AsQueryable();
                    pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                    MojiProizvodi = await PaginatedList<Proizvod>.CreateAsync(
                         proizvodIQ, pageIndex ?? 1, pageSize);
                }
                else
                {
                    MojiProizvodi = await PaginatedList<Proizvod>.CreateAsync(
                         new List<Proizvod>().AsQueryable(), pageIndex ?? 1, pageSize);
                }
                
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostIdiNaStranu()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                Console.WriteLine(pageInput + "++++++++++");
                return RedirectToPage("./MojiProizvodi", new { pageIndex = pageInput });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                HttpContext.Session.SetString("pageSize", brEl.ToString());
                return RedirectToPage("./MojiProizvodi", new { pageIndex = 1 });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostObrisiProizvod(string id)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idProdavac.ToString()).SingleOrDefault();
                if (pom != null)
                {
                    pom.MojiProizvodi.RemoveAll(x => x.Sifra == id.ToString());
                    coll.ReplaceOne(x => x.ID == idProdavac.ToString(), pom);
                    return RedirectToPage();
                }
                else
                {
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
