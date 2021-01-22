using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class KupacHomePageModel : PageModel
    {
        [BindProperty]
        public int Isporuceno { get; set; }
        [BindProperty]
        public int Naruceno { get; set; }
        [BindProperty]
        public int Korpa { get; set; }
        [BindProperty]
        public int Potvrdjeno { get; set; }
        [BindProperty]
        public int Odbijeno { get; set; }
        [BindProperty]
        public Kupac Ja { get; set; }
        public List<Narudzbina> narudzbine { get; set; }
        public int? idKupac { get; set; }
        private AppContext _db { get; set; }
        public KupacHomePageModel(AppContext db){
            _db=db;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet()
        {

        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

        }
    }
}
