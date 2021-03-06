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
    public class DodajKorisnikeModel : PageModel
    {
        public string ImeAdmina { get; set; }
        public string idAdmin{get;set;}
        private readonly IMongoDatabase _db;
        [BindProperty]
        public Kupac noviKupac{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}



        public DodajKorisnikeModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
        }
        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {
           
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                var coll = _db.GetCollection<Administrator>("Admins");
                var res = coll.Find(x=>x.ID==idAdmin.ToString()).SingleOrDefault();
                ImeAdmina = res.Mail;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostDodaj()
        {
          
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
                    var coll= _db.GetCollection<Kupac>("Kupci");
                    var filter1 = Builders<Kupac>.Filter.Eq(x => x.Email, noviKupac.Email);
                    var res = await coll.Find(filter1).ToListAsync();
                    Kupac pom =res.SingleOrDefault();
                    if (pom != null)
                    {
                        ErrorMessage = "Postoji nalog sa datom email adresom !";
                        return Page();
                    }
                    else
                    {
                        ErrorMessage = "";
                        await coll.InsertOneAsync(noviKupac);
                        return RedirectToPage("./AdminHomePage");
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
