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

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class DodajStofModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; }         
        public bool Ucitano { get; set; }
        private readonly IMongoDatabase _db;

        public string idProdavac{get;set;}

        //[BindProperty]
        //public IFormFile SlikaStofa{get;set;}

        [BindProperty(SupportsGet=true)]
        public Stof stofZaDodavanje{get;set;}

        [BindProperty]
        public TipStofa[] tipoviZaDodavanje{get;set;}

        [BindProperty(SupportsGet=true)]
        public int? brojTipova{get;set;}

        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        [BindProperty]
        public string ErrorMessage3{get;set;}


        public DodajStofModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            Ucitano =false;
            ErrorMessage1="";
            ErrorMessage2="";
            ErrorMessage3="";
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Ja = coll.Find(x=>x.ID==idProdavac.ToString()).SingleOrDefault();

                //noviProizvod.MojProdavac= new MongoDBRef("mojprodavac", idProdavac.ToString());
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostPrimeniAsync()
        {
            Console.WriteLine(brojTipova);
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                idProdavac = HttpContext.Session.GetString("idProdavac");
                if (brojTipova != null)
                {
                    ErrorMessage1 = "";
                    tipoviZaDodavanje = new TipStofa[(int)brojTipova];
                    return Page();
                }
                else
                {
                    ErrorMessage1 = "Niste uneli ni jedan broj novih tipova !";
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostDodajAsync()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idProdavac"));
            if (log)
            {
                
                        ErrorMessage1 = "";
                        ErrorMessage2 = "";
                        ErrorMessage3 = "";
                idProdavac = HttpContext.Session.GetString("idProdavac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                         Prodavac pom = coll.Find(x=>x.ID== idProdavac.ToString()).FirstOrDefault();
                        stofZaDodavanje.MojiTipovi = tipoviZaDodavanje.ToList();
                        stofZaDodavanje.Prodavac_ = new MongoDBRef("mojprodavac", idProdavac.ToString());
                if (pom.MojiStofovi == null)
                {
                    pom.MojiStofovi = new List<Stof>();
                }
                pom.MojiStofovi.Add(stofZaDodavanje);

                        coll.ReplaceOne(x => x.ID == idProdavac.ToString(), pom);

                        return RedirectToPage("./MojiStofovi");

            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            string idLog;
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
