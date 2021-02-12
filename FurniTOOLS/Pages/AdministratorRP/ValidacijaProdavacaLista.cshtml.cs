using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class ValidacijaProdavacaListaModel : PageModel
    {
        public string ImeAdmina { get; set; }
        public string idAdmin{get;set;}
        private readonly IMongoDatabase _db;
        public PaginatedList<Prodavac> Prodavci { get; set; }

        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}
        public ValidacijaProdavacaListaModel(IDatabaseSettings settings)
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
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                var coll = _db.GetCollection<Administrator>("Admins");
                var res = coll.Find(x=>x.ID==idAdmin.ToString()).SingleOrDefault();
                ImeAdmina = res.Mail;

                var coll2 = _db.GetCollection<Prodavac>("Prodavci");
                IQueryable<Prodavac> prodavciIQ = coll2.Find(x => x.Verifikovan==false).ToList().AsQueryable();

                pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                Prodavci = await PaginatedList<Prodavac>.CreateAsync(
                     prodavciIQ, pageIndex ?? 1, pageSize);
                
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

         public async Task<ActionResult> OnPostIdiNaStranu()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                Console.WriteLine(pageInput + "++++++++++");
                return RedirectToPage("./ValidacijaProdavacaLista", new { pageIndex = pageInput });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                HttpContext.Session.SetString("pageSize", brEl.ToString());
                return RedirectToPage("./ValidacijaProdavacaLista", new { pageIndex = 1 });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostVerifikuj(string id)
        {

             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                var coll2 = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll2.Find(x=>x.ID==id.ToString()).SingleOrDefault();
                if (pom != null)
                {
                    pom.Verifikovan = true;
                    coll2.ReplaceOne(x => x.ID == id.ToString(), pom);
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
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                HttpContext.Session.Remove("idAdmin");
                HttpContext.Session.Remove("imeAdmina");
                HttpContext.Session.Remove("prezimeAdmina");
                HttpContext.Session.Remove("emailAdmina");
            }
            return RedirectToPage("../Index");

        }
    }
}
