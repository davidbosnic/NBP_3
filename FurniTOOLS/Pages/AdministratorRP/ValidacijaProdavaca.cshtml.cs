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
    public class ValidacijaProdavacaModel : PageModel
    {
        private readonly IMongoDatabase _db;

        [BindProperty(SupportsGet=true)]
        public Prodavac prodavacZaIzmenu{get;set;}

        public int? idAdmin{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}
        public ValidacijaProdavacaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }

        public async Task<ActionResult> OnPost(int id)
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                idAdmin = idLog;
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                prodavacZaIzmenu = coll.Find(id.ToString()).SingleOrDefault();
                if (prodavacZaIzmenu != null)
                {
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
        public async Task<ActionResult> OnPostIzmeniProdavca()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idAdmin"), out idLog);
            if (log)
            {
                idAdmin = idLog;
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
