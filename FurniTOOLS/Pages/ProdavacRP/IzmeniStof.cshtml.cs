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
    public class IzmeniStofModel : PageModel
    {
        [BindProperty]
        public Prodavac Ja { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty(SupportsGet=true)]
        public int idStof { get; set; }
        public int? idProdavac{get;set;}
        [BindProperty(SupportsGet=true)]
        public Stof stofZaIzmenu{get;set;}
        [BindProperty(SupportsGet=true)]
        public int stofZaIzmenuID { get; set; }
        [BindProperty(SupportsGet=true)]
        public TipStofa[] tipoviStofa{get;set;}
        [BindProperty(SupportsGet=true)]
        public TipStofa tipZaDodavanje{get;set;}
        [BindProperty]
        public string ErrorMessage1{get;set;}
        [BindProperty]
        public string ErrorMessage2{get;set;}
        [BindProperty]

        public string ErrorMessage3{get;set;}
        [BindProperty]

        public IFormFile SlikaStofa{get;set;}

        [BindProperty]
        public bool Ucitano{get;set;}
        [BindProperty]

        public bool PromeniSliku{get;set;}

        public IzmeniStofModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage1 ="";
            ErrorMessage2="";
            ErrorMessage3="";
            PromeniSliku=false;
            Ucitano=false;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet(int id)
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {   //VAZNO !!! Ovde da vidimo da li po imenu da ga trazimo posto nema ID
                idProdavac = idLog;
                var coll = _db.GetCollection<Prodavac>("Prodavci");
       
                Prodavac pom = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();
                foreach (Stof s in pom.MojiStofovi)
                {
                    //ovo treba se menja
                    if (s.Naziv == id.ToString())
                    {
                        stofZaIzmenu = s;
                    }
                }
                tipoviStofa = stofZaIzmenu.MojiTipovi.ToArray();

                Ja = pom;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPost(int id)
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {   //VAZNO !!! Ovde da vidimo da li po imenu da ga trazimo posto nema ID
                idProdavac = idLog;
                var coll = _db.GetCollection<Prodavac>("Prodavci");

                Prodavac pom = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();
                foreach (Stof s in pom.MojiStofovi)
                {
                    //ovo treba se menja
                    if (s.Naziv == id.ToString())
                    {
                        stofZaIzmenu = s;
                    }
                }
                tipoviStofa = stofZaIzmenu.MojiTipovi.ToArray();

                Ja = pom;
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostDodajAsync()
        {
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idProdavac.ToString()).FirstOrDefault();
                stofZaIzmenu.Prodavac_ = new MongoDBRef("mojprodavac", idLog.ToString());
                stofZaIzmenu.MojiTipovi.Add(tipZaDodavanje);
                coll.ReplaceOne(x => x.ID == idLog.ToString(), pom);
                tipZaDodavanje = null;
                //ako menjamo da je preko ime onda i ovde izmena
                return RedirectToPage("./IzmeniStof", new { id = stofZaIzmenuID });
                
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostObrisiAsync(int idTip)
        {
            //OVA CELA MORA SE MENJA
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            if (log)
            {
                idProdavac = idLog;
                idStof = idTip;
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom = coll.Find(x=>x.ID==idLog.ToString()).FirstOrDefault();

                

                return RedirectToPage("./IzmeniStof", new { id = stofZaIzmenuID });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostIzmeniAsync()
        {
            //I ova cela ne moze ovako, mozda bolje da se obrisu ove stranice za izmenu ako nas mnogo kecaju xD
            int idLog;
            bool log = int.TryParse(HttpContext.Session.GetString("idProdavac"), out idLog);
            //tipoviStofa = _db.TipoviStofova.Where(x => x.MojiStof_.ID == stofZaIzmenuID).ToArray();
            if (log)
            {
                idProdavac = idLog;
                
                        ErrorMessage1 = "";
                        ErrorMessage2 = "";
                        ErrorMessage3 = "";
                       
                        //_db.Stofovi.Update(stofZaIzmenu);
                        //await _db.SaveChangesAsync();
                        return RedirectToPage("./MojiStofovi");
               
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

