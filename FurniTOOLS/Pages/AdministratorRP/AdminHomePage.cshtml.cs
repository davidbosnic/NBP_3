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
    public class AdminHomePageModel : PageModel
    {
        [BindProperty]
        public int BrAdmin { get; set; }
        [BindProperty]
        public int BrKupaca { get; set; }
        [BindProperty]
        public int BrVer { get; set; }
        [BindProperty]
        public int BrNeVer { get; set; }
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        public List<Prodavac> NeverifikovaniProdavci{get;set;}
        public List<Prodavac> VerifikovaniProdavci{get;set;}
        public List<Kupac> SviKorisnici{get;set;}
        private readonly IMongoDatabase _db;
        public AdminHomePageModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);

        }
        public async Task<ActionResult> OnGet()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                idAdmin = idLog;
                var coll = _db.GetCollection<Administrator>("Admins");
                Administrator pom = coll.Find(idAdmin.ToString()).FirstOrDefault();
                ImeAdmina = pom.Mail;
                var coll1 = _db.GetCollection<Prodavac>("Prodavci");
                var filter1 = Builders<Prodavac>.Filter.Where(x=>x.Verifikovan==false);
                var filter2= Builders<Prodavac>.Filter.Where(x => x.Verifikovan == true);
                //nzm kako drugacije da napravim neutralan filter
                var filter3 = Builders<Administrator>.Filter.Where(x => true);
                var filter4 = Builders<Kupac>.Filter.Where(x => true);
                var coll2 = _db.GetCollection<Kupac>("Kupci");
                NeverifikovaniProdavci = await coll1.Find(filter1).ToListAsync();
                VerifikovaniProdavci = await coll1.Find(filter2).ToListAsync();
                BrNeVer = NeverifikovaniProdavci.Count;
                BrVer = VerifikovaniProdavci.Count;
                BrAdmin = (int)coll.CountDocuments(filter3);
                BrKupaca = (int)coll2.CountDocuments(filter4);
                SviKorisnici = coll2.Find(x => true).ToList();
                return Page();
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
                var coll1 = _db.GetCollection<Prodavac>("Prodavci");
                var res=await coll1.FindAsync(id.ToString());
                Prodavac zaBrisanje = res.SingleOrDefault();
                if (zaBrisanje != null)
                {
                    coll1.DeleteOne(id.ToString());
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
        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
    }
}
