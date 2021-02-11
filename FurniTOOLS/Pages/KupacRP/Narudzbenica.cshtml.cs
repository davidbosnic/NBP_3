using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class NarudzbenicaModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public string IzabraniStofID { get; set; }
        [BindProperty(SupportsGet=true)]

        public string ProizvodID { get; set; }
        [BindProperty(SupportsGet=true)]
        public string ProdavacID { get; set; }
        [BindProperty]
        public Kupac Ja { get; set; }  
        [BindProperty]      
        public string idKupac { get; set; }
        [BindProperty]
        public Proizvod Proizvod { get; set; }
        private readonly IMongoDatabase _db;
        [BindProperty]
        public Narudzbina Narudzbina { get; set; }
        public bool Ucitano { get; set; }
        public string ErrorMessage{get;set;}
        public List<Stof> Stofovi { get; set; }
        public NarudzbenicaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            Ucitano =false;
            ErrorMessage="";
        }   

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnPostAsync(string id, string prodavac)
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom1 = coll.Find(x => x.ID == prodavac).SingleOrDefault();

                Proizvod = pom1.MojiProizvodi.Where(x => x.Sifra == id).SingleOrDefault();
                Proizvod.MojProdavac_ = pom1;
                ProdavacID = pom1.ID;
                ProizvodID = Proizvod.Sifra;
                Stofovi = pom1.MojiStofovi;

                
                Console.WriteLine(Proizvod.ID);

                var coll2 = _db.GetCollection<Kupac>("Kupci");


                Ja = coll2.Find(x => x.ID == idKupac).SingleOrDefault();
                Console.WriteLine(Ja.ID);
                Console.WriteLine(Ja.Adresa);
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostStaviUKorpu()
        {
            
            if (IzabraniStofID == null)
            {
                ErrorMessage = "Morate izabrati stof!";
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                Prodavac pom1 = coll.Find(x => x.ID == ProdavacID).SingleOrDefault();
                Stofovi = pom1.MojiStofovi;
                return Page();
            }

            string idk = HttpContext.Session.GetString("idKupac");

            Narudzbina.ProfilKorisnika = new MongoDBRef("profilkorisnika",idk);

            var coll2 = _db.GetCollection<Prodavac>("Prodavci");
            Prodavac pom2 = coll2.Find(x => x.ID == ProdavacID).SingleOrDefault();
            Proizvod pom3 = pom2.MojiProizvodi.Where(x => x.Sifra == ProizvodID).SingleOrDefault();

            string stofpom = IzabraniStofID.Split(" ")[0];
            string tippom = IzabraniStofID.Split(" ")[1];

            Narudzbina.NarucenProizvod_ = pom3;
            Narudzbina.NarucenStof = pom2.MojiStofovi.Where(x => x.Naziv == stofpom).SingleOrDefault();
            Narudzbina.Status = "Korpa";

            Narudzbina.NarucenStof_ = Narudzbina.NarucenStof.MojiTipovi.Where(x=>x.SifraStofa==tippom).SingleOrDefault();
            Narudzbina.VremeNarucivanja = DateTime.Now;

            var coll4 = _db.GetCollection<Narudzbina>("Narudzbine");
            coll4.InsertOne(Narudzbina);

            var coll5 = _db.GetCollection<Kupac>("Kupci");
            Kupac pomk = coll5.Find(x => x.ID == idk).SingleOrDefault();
            if (pomk.MojeNarudzbine_==null)
            {
                pomk.MojeNarudzbine_ = new List<MongoDBRef>();
            }
            pomk.MojeNarudzbine_.Add(new MongoDBRef("mojenarudzbine", Narudzbina.ID));
            coll5.ReplaceOne(x => x.ID == idk,pomk);

            Console.WriteLine("asdaf");
            return RedirectToPage("./KupacHomePage");
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            string idLog;
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                HttpContext.Session.Remove("idKupac");
                HttpContext.Session.Remove("imeKupca");
                HttpContext.Session.Remove("prezimeKupca");
                HttpContext.Session.Remove("emailKupca");
            }
            return RedirectToPage("../Index");
        }
    }
}
