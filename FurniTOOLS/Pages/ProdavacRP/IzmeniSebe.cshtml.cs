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
    public class IzmeniSebeModel : PageModel
    {
        public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty(SupportsGet=true)]

        public Prodavac prodavacZaIzmenu {get;set;}

        public string ErrorMessage{get;set;}

        public int? idProdavac{get;set;}

        public IzmeniSebeModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
            Ucitano=false;
        }

        public async Task<ActionResult> OnGet()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                //Ja=_db.Prodavci.Where(x=>x.ID==idProdavac).SingleOrDefault();
                var coll = _db.GetCollection<Prodavac>("Prodavci");
          
                prodavacZaIzmenu = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();
                Console.WriteLine(prodavacZaIzmenu.Ime);
                return Page();
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
        public async Task<ActionResult> OnPostIzmeni()
        {
            Ucitano = true;
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                if (!ModelState.IsValid)
                {
                    Console.WriteLine(prodavacZaIzmenu.Email);
                    Console.WriteLine(prodavacZaIzmenu.Firma);
                    Console.WriteLine(prodavacZaIzmenu.Sifra);
                    Console.WriteLine(prodavacZaIzmenu.Ime);
                    Console.WriteLine(prodavacZaIzmenu.Prezime);
                    Console.WriteLine(prodavacZaIzmenu.Grad);
                    Console.WriteLine(prodavacZaIzmenu.Verifikovan);
                    Console.WriteLine(prodavacZaIzmenu.ID);
                    Console.WriteLine(prodavacZaIzmenu.BrojTelefona);
                    Console.WriteLine(prodavacZaIzmenu.Adresa);
                    return Page();
                }
                else
                {
                    
                        ErrorMessage = "";
                    var coll = _db.GetCollection<Prodavac>("Prodavci");
                    coll.ReplaceOne(x => x.ID == idLog.ToString(),prodavacZaIzmenu);

                        HttpContext.Session.SetString("imeProdavca", prodavacZaIzmenu.Ime);
                        HttpContext.Session.SetString("prezimeProdavca", prodavacZaIzmenu.Prezime);
                        HttpContext.Session.SetString("emailProdavca", prodavacZaIzmenu.Email);
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
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
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
