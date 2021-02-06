using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class IzmeniKorisnikeModel : PageModel
    {
        public bool Ucitano { get; set; }
        public string ImeAdmina { get; set; }
        [BindProperty]
        public Kupac noviKupac{get;set;}
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}

        public IzmeniKorisnikeModel(AppContext db)
        {
            _db=db;
            ErrorMessage="";
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnPost(int id)
        {
            return Page();
        }  
        public async Task<ActionResult> OnPostIzmeni()
        {
            return Page();
        } 
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();

        }     
    }
}
