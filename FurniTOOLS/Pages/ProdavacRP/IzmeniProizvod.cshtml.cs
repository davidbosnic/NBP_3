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
        public string idProdavac{get;set;}

        [BindProperty(SupportsGet=true)]
        public Proizvod proizvodZaIzmenu{get;set;}

        [BindProperty]
        public Prodavac Ja { get; set; } 
        public IzmeniProizvodModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage1 ="";
            ErrorMessage2="";
           
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPost(string id)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                Console.WriteLine(id + " " + idProdavac);
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                
                Prodavac pom = coll.Find(x=>x.ID== idProdavac.ToString()).FirstOrDefault();
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
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                
                ErrorMessage1 = "";
                ErrorMessage2 = "";
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID== idProdavac.ToString()).FirstOrDefault();
                proizvodZaIzmenu.MojProdavac = new MongoDBRef("mojprodavac", idProdavac.ToString());
                for (int i=0;i<=pom.MojiProizvodi.Count;i++)
                {
                    if (pom.MojiProizvodi[i].Sifra==proizvodZaIzmenu.Sifra)
                    {
                        pom.MojiProizvodi[i] = proizvodZaIzmenu;
                    }
                }
                coll.ReplaceOne(x => x.ID == idProdavac.ToString(), pom);

                return RedirectToPage("./ProdavacHomePage");
                 
            }
            return RedirectToPage("../Index");
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
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
