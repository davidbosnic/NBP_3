using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;
using static System.Net.Mime.MediaTypeNames;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class IzmeniProizvodModel : PageModel
    {
        [BindProperty]
        public int idProizvod { get; set; }
        public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        public int? idProdavac{get;set;}

        [BindProperty(SupportsGet=true)]
        public Proizvod proizvodZaIzmenu{get;set;}

        //[BindProperty]
        //public IFormFile Slika {get;set;}

        //[BindProperty]
        //public bool PromeniSliku{get;set;}
        [BindProperty]
        public Prodavac Ja { get; set; } 
        public IzmeniProizvodModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage1 ="";
            ErrorMessage2="";
            //PromeniSliku=false;
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPost(int id)
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                idProizvod = id;
                Console.WriteLine(id + " " + idProdavac);
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                //moracemo ovde verovanto da prosledimo sifru proizvoda posto on nema svoj id jer se ne cuva u zasebnu kolekciju
                Prodavac pom = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();
                foreach (Proizvod p in pom.MojiProizvodi)
                {
                    if (p.Sifra==id.ToString())
                    {
                        proizvodZaIzmenu = p;
                    }
                }

                Ja = pom;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIzmeni()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                
                ErrorMessage1 = "";
                ErrorMessage2 = "";
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();
                proizvodZaIzmenu.MojProdavac = new MongoDBRef("mojprodavac", idLog.ToString());
                for (int i=0;i<=pom.MojiProizvodi.Count;i++)
                {
                    if (pom.MojiProizvodi[i].Sifra==proizvodZaIzmenu.Sifra)
                    {
                        pom.MojiProizvodi[i] = proizvodZaIzmenu;
                    }
                }
                coll.ReplaceOne(x => x.ID == idLog.ToString(), pom);

                return RedirectToPage("./ProdavacHomePage");
                 
            }
            return RedirectToPage("../Index");
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
