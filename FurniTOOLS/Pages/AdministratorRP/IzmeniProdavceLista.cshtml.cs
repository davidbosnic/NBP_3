using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class IzmeniProdavceListaModel : PageModel
    {
       
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}
        public PaginatedList<Prodavac> Prodavci { get; set; }

        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}
        public IzmeniProdavceListaModel(AppContext db)
        {
            _db=db;
            pageInput=1;
        }

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<IActionResult> OnGet(int? pageIndex)
        {
            
        }

         public async Task<ActionResult> OnPostIdiNaStranu()
        {
            
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
           
        }
        public async Task<ActionResult> OnPostObrisiProdavca(int id)
        {
            
            
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            
            
        }
    }
}
