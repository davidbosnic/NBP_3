using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class AdminHomePageModel : PageModel
    {
        [BindProperty]
        public int BrAdmin { get; set; }
        [BindProperty]
        public int BrKupaca { get; set; }
        [BindProperty]
        public int BrVer { get; set; }
        [BindProperty]
        public int BrNeVer { get; set; }
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}
        public List<Prodavac> NeverifikovaniProdavci{get;set;}
        public List<Prodavac> VerifikovaniProdavci{get;set;}
        public List<Kupac> SviKorisnici{get;set;}
        public AdminHomePageModel(AppContext db)
        {
            _db=db;
        }
        public async Task<ActionResult> OnGet()
        {
            return Page();

        }
        public async Task<ActionResult> OnPostObrisiProdavca(int id)
        {
            return Page();
        }
        
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
    }
}
