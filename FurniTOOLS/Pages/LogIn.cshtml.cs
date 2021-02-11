using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FurniTOOLS.Models;
using MongoDB.Driver;

namespace WEBFurniTOOLS
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public int Type { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }
        private readonly IMongoDatabase _db;
        public LogInModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            //_db = database.GetCollection<Administrator>(settings.AdminsCollectionName);
            Message ="";
        }
        public async Task<IActionResult> OnPostLogin()
        {

            if (Type == 0)
            {
                var coll = _db.GetCollection<Administrator>("Admins");
                var filter1 = (Builders<Administrator>.Filter.Eq(x => x.Mail, Email) & Builders<Administrator>.Filter.Eq(x => x.Sifra, Password));
                //var filter2 = Builders<Administrator>.Filter.Eq("sifra", Password);

                var result = await coll.Find(filter1).ToListAsync();
                var admin = result.SingleOrDefault();

                Console.WriteLine(admin.Ime + " " + admin.ID);

                if (admin != null && Password == admin.Sifra)
                {
                    HttpContext.Session.SetString("idAdmin", admin.ID.ToString());
                    HttpContext.Session.SetString("pageSize", Convert.ToString(5));

                    HttpContext.Session.SetString("imeAdmina", admin.Ime);
                    HttpContext.Session.SetString("prezimeAdmina", admin.Prezime);
                    HttpContext.Session.SetString("emailAdmina", admin.Mail);


                    return RedirectToPage("./AdministratorRP/AdminHomePage");
                }
                else
                {
                    Message = "Email i sifra se ne poklapaju!";
                    return Page();
                }

            }
            else if (Type == 1)
            {
                var coll = _db.GetCollection<Kupac>("Kupci");
                var filter1 = (Builders<Kupac>.Filter.Eq(x => x.Email, Email) & Builders<Kupac>.Filter.Eq(x => x.Sifra, Password));
                //var filter2 = Builders<Administrator>.Filter.Eq("sifra", Password);

                var result = await coll.Find(filter1).ToListAsync();
                var kupac = result.SingleOrDefault();
                if (kupac != null && Password == kupac.Sifra)
                {
                    HttpContext.Session.SetString("idKupac", kupac.ID.ToString());
                    HttpContext.Session.SetString("pageSize", Convert.ToString(5));

                    HttpContext.Session.SetString("imeKupca", kupac.Ime);
                    HttpContext.Session.SetString("prezimeKupca", kupac.Prezime);
                    HttpContext.Session.SetString("emailKupca", kupac.Email);
                    return RedirectToPage("./KupacRP/KupacHomePage");
                }
                else
                {
                    Message = "Email i sifra se ne poklapaju!";
                    return Page();
                }
            }
            else
            {
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                var filter1 = (Builders<Prodavac>.Filter.Eq(x => x.Email, Email) & Builders<Prodavac>.Filter.Eq(x => x.Sifra, Password));
                //var filter2 = Builders<Administrator>.Filter.Eq("sifra", Password);

                var result = await coll.Find(filter1).ToListAsync();
                var prodavac = result.SingleOrDefault();
                if (prodavac != null && Password == prodavac.Sifra)
                {
                    if (!prodavac.Verifikovan)
                    {
                        Message = "Nalog vam jos nije verifikovan!";
                        return Page();
                    }
                    else
                    {
                        HttpContext.Session.SetString("idProdavac", prodavac.ID.ToString());
                        HttpContext.Session.SetString("pageSize", Convert.ToString(5));

                        HttpContext.Session.SetString("imeProdavca", prodavac.Ime);
                        HttpContext.Session.SetString("prezimeProdavca", prodavac.Prezime);
                        HttpContext.Session.SetString("emailProdavca", prodavac.Email);

                        return RedirectToPage("./ProdavacRP/ProdavacHomePage");
                    }
                }
                else
                {
                    Message = "Email i sifra se ne poklapaju!";
                    return Page();
                }
            }
           
        }
    }
}
