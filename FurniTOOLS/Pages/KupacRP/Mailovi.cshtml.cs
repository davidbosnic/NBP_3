using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class MailoviModel : PageModel
    {
        [BindProperty]
        public Kupac Ja { get; set; }        
        public int? idKupac { get; set; }
        private AppContext _db { get; set; }
        public List<Narudzbina> Narudzbine { get; set; }
        public int? IzabraniID { get; set; }
        public MailoviModel(AppContext db){
            _db=db;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet()
        {

        }
        public async Task<IActionResult> OnPostObrisi(int id)
        {

        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

        }
    }
}
