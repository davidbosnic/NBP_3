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
    public class IzmeniProdavceListaModel : PageModel
    {
       
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        private readonly IMongoDatabase _db;
        public PaginatedList<Prodavac> Prodavci { get; set; }

        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}
        public IzmeniProdavceListaModel(IDatabaseSettings settings)
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
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                idAdmin = idLog;
                var coll = _db.GetCollection<Administrator>("Admins");
                var res = coll.Find(x=>x.ID==idAdmin.ToString()).SingleOrDefault();
                ImeAdmina = res.Mail;

                var coll2 = _db.GetCollection<Prodavac>("Prodavci");
                IQueryable<Prodavac> prodavciIQ = coll2.Find(x => true).ToList().AsQueryable();

                pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                Prodavci = await PaginatedList<Prodavac>.CreateAsync(
                     prodavciIQ, pageIndex ?? 1, pageSize);
                //Kupci=  _db.Kupci.ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

         public async Task<ActionResult> OnPostIdiNaStranu()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                Console.WriteLine(pageInput + "++++++++++");
                return RedirectToPage("./IzmeniProdavceLista", new { pageIndex = pageInput });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                HttpContext.Session.SetString("pageSize", brEl.ToString());
                return RedirectToPage("./IzmeniProdavceLista", new { pageIndex = 1 });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostObrisiProdavca(int id)
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                idAdmin = idLog;
                var coll2 = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac zaBrisanje = coll2.Find(x => x.ID == id.ToString()).SingleOrDefault();
                if (zaBrisanje != null)
                {
                    coll2.DeleteOne(x => x.ID == id.ToString());
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
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
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
