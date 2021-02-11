using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace WEBFurniTOOLS
{
    public class SigninModel : PageModel
    {

        [BindProperty]
        public string Firma { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        
        [BindProperty]
        public Prodavac Prodavac { get; set; }
        public string ErrorMessage { get; set; }
        [BindProperty]
        public int Type { get; set; }
        public void OnGet()
        {
        }
        private readonly IMongoDatabase _db;
        public SigninModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            ErrorMessage ="";
        }
        public async Task<IActionResult> OnPostSignup()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine(Type);
            if (Type == 1)
            {
                Kupac k = new Kupac();
                k.Ime = Prodavac.Ime;
                k.Prezime = Prodavac.Prezime;
                k.Email = Prodavac.Email;
                k.Sifra = Prodavac.Sifra;
                k.BrojTelefona = Prodavac.BrojTelefona;
                k.Adresa = Prodavac.Adresa;
                k.Grad = Prodavac.Grad;
                k.MojeNarudzbine_ = new List<MongoDBRef>();
                var coll = _db.GetCollection<Kupac>("Kupci");
                coll.InsertOne(k);
                return RedirectToPage("./Index");
            }
            else
            {
                
                   
                Prodavac.Verifikovan = false;
                Prodavac.MojeNarudzbine = new List<MongoDBRef>();
                Prodavac.MojiProizvodi = new List<Proizvod>();
                Prodavac.MojiStofovi = new List<Stof>();
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                coll.InsertOne(Prodavac);
                return RedirectToPage("./Index");

            }
        }
    }
}
