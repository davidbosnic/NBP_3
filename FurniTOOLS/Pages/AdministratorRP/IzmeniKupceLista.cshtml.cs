using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.AdministratorRP
{
    public class IzmeniKupceListaModel : PageModel
    {
        public string ImeAdmina { get; set; }
        public int? idAdmin{get;set;}
        public AppContext _db{get;set;}
        public PaginatedList<Kupac> Kupci { get; set; }

        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]
        public int pageSize{get;set;}
        public IzmeniKupceListaModel(AppContext db)
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
            return Page();
        }

         public async Task<ActionResult> OnPostIdiNaStranu()
        {
            return Page();
        }
        public async Task<ActionResult> OnPostBrojElemenataNaStrani(int brEl)
        {
            return Page();
        }
        public async Task<ActionResult> OnPostObrisiKupca(int id)
        {

            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
