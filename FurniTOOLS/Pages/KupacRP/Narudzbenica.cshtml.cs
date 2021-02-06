using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class NarudzbenicaModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public int IzabraniStofID { get; set; }
        [BindProperty(SupportsGet=true)]

        public int ProizvodID { get; set; }
        [BindProperty(SupportsGet=true)]
        public int ProdavacID { get; set; }
        [BindProperty]
        public Kupac Ja { get; set; }  
        [BindProperty]      
        public int? idKupac { get; set; }
        [BindProperty]
        public Proizvod Proizvod { get; set; }
        private AppContext _db { get; set; }
        [BindProperty]
        public Narudzbina Narudzbina { get; set; }
        public bool Ucitano { get; set; }
        public string ErrorMessage{get;set;}
        public List<Stof> Stofovi { get; set; }
        public NarudzbenicaModel(AppContext db){
            _db=db;
            Ucitano=false;
            ErrorMessage="";
        }   

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            return Page();
        }
        public async Task<IActionResult> OnPostStaviUKorpu()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
