using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class IzmeniSebeModel : PageModel
    {
        public bool Ucitano { get; set; }
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}
        
        [BindProperty(SupportsGet=true)]
        public Administrator Admin{get;set;}

        [BindProperty]
        public string ErrorMessage{get;set;}

        public IzmeniSebeModel(AppContext db)
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
            
        }
        public async Task<ActionResult> OnPostIzmeniSe()
        {
            
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            
            
        }
    }
}
