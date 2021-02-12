using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurniTOOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class KupovinaModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public double CenaDO { get; set; }
        [BindProperty(SupportsGet=true)]
        public double CenaOD { get; set; }
        [BindProperty]
        public bool Cena { get; set; }
        [BindProperty]
        public Kupac Ja { get; set; }
        public string idKupac { get; set; }
        public List<Prodavac> Prodavci { get; set; }
        public List<Proizvod> Proizvodi { get; set; }
        public SelectList ImenaProizvoda { get; set; }
        public SelectList ImenaFirmi { get; set; }
        public PaginatedList<Proizvod> ListaZaPrikaz { get; set; }
        [BindProperty (SupportsGet=true)]
        public string? Search1 {get; set;}

        [BindProperty (SupportsGet=true)]
        public string? Search3 {get; set;}
        private readonly IMongoDatabase _db;
        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}
        public KupovinaModel(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _db = client.GetDatabase(settings.DatabaseName);
            pageInput =1;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet(int? pageIndex)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                Search1 = HttpContext.Session.GetString("Search1");
                Search3 = HttpContext.Session.GetString("Search3");
                CenaOD = Convert.ToInt32(HttpContext.Session.GetString("OD"));
                CenaDO = Convert.ToInt32(HttpContext.Session.GetString("DO"));
                Cena = bool.TryParse(HttpContext.Session.GetString("Cena"), out bool result);
                Cena = result;
                Console.WriteLine($"{Search1}---{Search3}");
                idKupac = HttpContext.Session.GetString("idKupac");
                var coll = _db.GetCollection<Prodavac>("Prodavci");
                List<Prodavac> pom = coll.Find(x => true).ToList<Prodavac>();
                Proizvodi = new List<Proizvod>();
                if (pom!=null)
                {
                    foreach(Prodavac p in pom)
                    {
                        Proizvodi = Proizvodi.Concat(p.MojiProizvodi).ToList();
                    }
                }
                foreach (Proizvod pp in Proizvodi)
                {
                    var filter = Builders<Prodavac>.Filter.Eq(e => e.ID, pp.MojProdavac.Id.AsString);
                    Prodavac npom = coll.Find(filter).SingleOrDefault();
                    pp.MojProdavac_ = npom;
                }



                IQueryable<string> nesto = Proizvodi.AsQueryable().Select(x => x.Naziv).Distinct();
                var coll1 = _db.GetCollection<Kupac>("Kupci");


                Ja = coll1.Find(x => x.ID == idKupac).SingleOrDefault();
                ImenaProizvoda = new SelectList(nesto.ToList());
                ImenaFirmi = new SelectList(pom.AsQueryable().Select(x => x.Firma).Distinct().ToList());
                Prodavci = pom;

                Console.WriteLine(Search1 + " " + Search3);
                IQueryable<Proizvod> zaPrikaz = null;
                if (Search1 != null && Search1 != "0")
                {
                    zaPrikaz = Proizvodi.AsQueryable().Where(x => x.Naziv == Search1);
                }
                else if (Search3 != null && Search3 != "0")
                {
                    if (zaPrikaz == null)
                        zaPrikaz = Proizvodi.AsQueryable().Where(x => x.MojProdavac_.Firma == Search3);
                    else
                        zaPrikaz = zaPrikaz.Where(x => x.MojProdavac_.Firma == Search3);
                }
                if (zaPrikaz == null)
                    zaPrikaz = Proizvodi.AsQueryable();
                if (Cena)
                {
                    zaPrikaz = zaPrikaz.Where(x => x.CenaPoKomadu <= CenaDO && x.CenaPoKomadu >= CenaOD);
                    Cena = true;
                }
                pageSize = Convert.ToInt32(HttpContext.Session.GetString("pageSize"));
                ListaZaPrikaz = await PaginatedList<Proizvod>.CreateAsync(
                     zaPrikaz, pageIndex ?? 1, pageSize);
                return Page();
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<ActionResult> OnPostIdiNaStranu()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                Console.WriteLine(pageInput + "++++++++++");
                HttpContext.Session.SetString("Search1", string.IsNullOrEmpty(Search1) ? "0" : Search1.ToString());
                HttpContext.Session.SetString("Search3", string.IsNullOrEmpty(Search3) ? "0" : Search3.ToString());
                HttpContext.Session.SetString("DO", CenaDO.ToString());
                HttpContext.Session.SetString("OD", CenaOD.ToString());
                HttpContext.Session.SetString("Cena", Cena.ToString());
                return RedirectToPage("./Kupovina", new { pageIndex = pageInput });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                HttpContext.Session.SetString("pageSize", brEl.ToString());
                HttpContext.Session.SetString("Search1", string.IsNullOrEmpty(Search1) ? "0" : Search1.ToString());
                HttpContext.Session.SetString("Search3", string.IsNullOrEmpty(Search3) ? "0" : Search3.ToString());
                HttpContext.Session.SetString("DO", CenaDO.ToString());
                HttpContext.Session.SetString("OD", CenaOD.ToString());
                HttpContext.Session.SetString("Cena", Cena.ToString());
                return RedirectToPage("./Kupovina", new { pageIndex = 1 });
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostPretrazi()
        {
            Console.WriteLine(Search1 + " --- " + Search3 + " --- " + Cena + " --- " + CenaDO + " --- " + CenaDO);
            HttpContext.Session.SetString("Search1", string.IsNullOrEmpty(Search1) ? "0" : Search1.ToString());
            HttpContext.Session.SetString("Search3", string.IsNullOrEmpty(Search3) ? "0" : Search3.ToString());
            HttpContext.Session.SetString("DO", CenaDO.ToString());
            HttpContext.Session.SetString("OD", CenaOD.ToString());
            HttpContext.Session.SetString("Cena", Cena.ToString());

            return RedirectToPage();
        }
        public double MaxCena()
        {
            double max = 0;
            foreach (var item in Proizvodi)
            {
                if(item.CenaPoKomadu>max)
                    max=item.CenaPoKomadu;
            }
            return max;
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
             
            bool log = !string.IsNullOrEmpty(HttpContext.Session.GetString("idKupac"));
            if (log)
            {
                HttpContext.Session.Remove("DO");
                HttpContext.Session.Remove("OD");
                HttpContext.Session.Remove("Cena");
                HttpContext.Session.Remove("idKupac");
                HttpContext.Session.Remove("imeKupca");
                HttpContext.Session.Remove("prezimeKupca");
                HttpContext.Session.Remove("emailKupca");
                HttpContext.Session.Remove("Search1");
                HttpContext.Session.Remove("Search3");
            }
            return RedirectToPage("../Index");
        }
    }
}
