using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class IzmeniProdavcaModel : PageModel
    {
        public bool Ucitano { get; set; }
        [BindProperty(SupportsGet=true)]
        public string ImeAdmina { get; set; }
        [BindProperty(SupportsGet=true)]
        public Prodavac prodavacZaIzmenu{get;set;}
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}

        public IzmeniProdavcaModel(AppContext db)
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
            
        }  
        public async Task<ActionResult> OnPostIzmeni()
        {
           
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            
            
        }
    }
}
