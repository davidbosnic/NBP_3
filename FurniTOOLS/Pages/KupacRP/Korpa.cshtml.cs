using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class KorpaModel : PageModel
    {
        [BindProperty]
        public Kupac Ja { get; set; }
        public List<Narudzbina> narudzbine { get; set; }
        public int? idKupac { get; set; }
        public AppContext _db { get; set; }
        public KorpaModel(AppContext db)
        {
            _db=db;
        }

        public double ukupno()
        {
            double ukupno=0;
            foreach (var item in narudzbine)
            {
                ukupno+=item.CenaBato();
            }
            return ukupno;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostIzbaci(int id)
        {
            return Page();
        }
        public async Task<IActionResult> OnPostKupi()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
