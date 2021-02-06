using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class DodajProdavcaModel : PageModel
    {
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}
        [BindProperty]
        public Prodavac noviProdavac{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}



        public DodajProdavcaModel(AppContext db)
        {
            _db=db;
            ErrorMessage="";
    
        }
        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostDodaj()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();

        }
    }
}
