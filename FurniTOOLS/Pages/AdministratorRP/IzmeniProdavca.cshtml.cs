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
    public class IzmeniProdavcaModel : PageModel
    {
        public bool Ucitano { get; set; }
        [BindProperty(SupportsGet=true)]
        public string ImeAdmina { get; set; }
        [BindProperty(SupportsGet=true)]
        public Prodavac prodavacZaIzmenu{get;set;}
        public string idAdmin{get;set;}
        private readonly IMongoDatabase _db;

        [BindProperty]
        public string ErrorMessage{get;set;}

        public IzmeniProdavcaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPost(string id)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                var coll = _db.GetCollection<Administrator>("Admins");
                var res = coll.Find(x=>x.ID==idAdmin.ToString()).SingleOrDefault();
                ImeAdmina = res.Mail;

                var coll2 = _db.GetCollection<Prodavac>("Prodavci");
                var res1 = await coll2.FindAsync(x=>x.ID==id.ToString());
                prodavacZaIzmenu = res1.SingleOrDefault();
                if (prodavacZaIzmenu != null)
                {
                    Console.WriteLine(id);
                    return Page();
                }
                else
                {
                    return RedirectToPage("./AdminHomePage");
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }  
        public async Task<ActionResult> OnPostIzmeni()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    var coll = _db.GetCollection<Prodavac>("Prodavci");
                    var filter1 = (Builders<Prodavac>.Filter.Eq(x => x.Email, prodavacZaIzmenu.Email) & Builders<Prodavac>.Filter.Ne(x => x.ID, prodavacZaIzmenu.ID));
                    Prodavac pom = coll.Find(filter1).SingleOrDefault();
                    if (pom != null)
                    {
                        ErrorMessage = "Postoji nalog sa datom email adresom !";
                        return Page();
                    }
                    else
                    {
                        ErrorMessage = "";
                        coll.ReplaceOne(x => x.ID == prodavacZaIzmenu.ID, prodavacZaIzmenu);

                        return RedirectToPage("AdminHomePage");
                    }
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

            string idLog;
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
