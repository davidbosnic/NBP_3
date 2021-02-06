using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class ValidacijaProdavacaModel : PageModel
    {
        public AppContext _db{get;set;}

        [BindProperty(SupportsGet=true)]
        public Prodavac prodavacZaIzmenu{get;set;}

        public int? idAdmin{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}
        public ValidacijaProdavacaModel(AppContext db)
        {
            _db=db;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }

        public async Task<ActionResult> OnPost(int id)
        {
            return Page();

        }
        public async Task<ActionResult> OnPostIzmeniProdavca()
        {
            return Page();

        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

            return Page();
        }
    }
}
