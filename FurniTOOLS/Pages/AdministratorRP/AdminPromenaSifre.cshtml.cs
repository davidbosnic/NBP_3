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
    public class AdminPromenaSifreModel : PageModel
    {
        public bool Ucitano { get; set; }
        public string ImeAdmina { get; set; }
        public string idAdmin{get;set;}
        private readonly IMongoDatabase _db;

        [BindProperty(SupportsGet=true)]
        public Administrator Admin{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}

        [BindProperty]
        public string novaSifra{get;set;}

        [BindProperty]
        public string novaSifraPonovo{get;set;}

        [BindProperty]
        public string staraSifra{get;set;}

        public AdminPromenaSifreModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
            Ucitano=false;
        }

        public async Task<ActionResult> OnGet()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");
                var coll = _db.GetCollection<Administrator>("Admins");
                //Ja=_db.Kupci.Where(x=>x.ID==idKupac).SingleOrDefault();
                Admin = coll.Find(x=>x.ID==idAdmin.ToString()).SingleOrDefault();
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostIzmeni()
        {
            Ucitano = true;
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idAdmin"));
            if (log)
            {
                idAdmin = HttpContext.Session.GetString("idAdmin");

                var coll = _db.GetCollection<Administrator>("Admins");

                Administrator pom = coll.Find(x => x.ID == idAdmin.ToString()).SingleOrDefault();
                if (pom.Sifra != staraSifra)
                {
                    ErrorMessage = "Pogrešili ste trenutnu šifru";
                    return Page();
                }
                if (novaSifra != novaSifraPonovo)
                {
                    ErrorMessage = "Niste uneli dva puta istu šifru";
                    return Page();
                }
                else
                {
                    ErrorMessage = "";
                    Admin = coll.Find(x => x.ID == idAdmin.ToString()).SingleOrDefault();
                    Admin.Sifra = novaSifra;
                    //ovo je valjda update nisam siguran
                    coll.ReplaceOne(x => x.ID == Admin.ID, Admin);
                    return RedirectToPage("./AdminHomePage");
                }


            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
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