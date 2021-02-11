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
    public class IzmeniSebeModel : PageModel
    {
        public bool Ucitano { get; set; }
        public string ImeAdmina { get; set; }
        public string idAdmin{get;set;}
        private readonly IMongoDatabase _db;

        [BindProperty(SupportsGet=true)]
        public Administrator Admin{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}

        public IzmeniSebeModel(IDatabaseSettings settings)
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
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                
                var coll = _db.GetCollection<Administrator>("Admins");
                var res = coll.Find(x=>x.ID==idAdmin.ToString()).SingleOrDefault();
                ImeAdmina = res.Mail;
                Admin = res;
                if (Admin != null)
                {
                    return Page();
                }
                else
                {
                    return RedirectToPage("../Index");
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIzmeniSe()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                if (ModelState.IsValid)
                {
                    var coll = _db.GetCollection<Administrator>("Admins");
                    var filter1 = (Builders<Administrator>.Filter.Eq(x => x.Mail, Admin.Mail) & Builders<Administrator>.Filter.Ne(x => x.ID, Admin.ID));
                    Administrator pom = coll.Find(filter1).SingleOrDefault();
                 
                    if (pom != null)
                    {
                        ErrorMessage = "Postoji admin sa unesenim mailom !";
                        return Page();
                    }
                    else
                    {
                        ErrorMessage = "";

                        coll.ReplaceOne(x => x.ID == Admin.ID,Admin);

                        HttpContext.Session.SetString("imeAdmina", Admin.Ime);
                        HttpContext.Session.SetString("prezimeAdmina", Admin.Prezime);
                        HttpContext.Session.SetString("emailAdmina", Admin.Mail);
                        return RedirectToPage("./AdminHomePage");
                    }
                }
                else
                {
                    return Page();
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
