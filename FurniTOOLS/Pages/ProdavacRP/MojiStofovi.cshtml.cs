using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class MojiStofoviModel : PageModel
    {
        public AppContext _db{get;set;}

        public PaginatedList<Stof> MojiStofovi{get;set;}
        public int? idProdavac{get;set;}
        public MojiStofoviModel(AppContext db)
        {
            _db=db;
            pageInput=1;
        }
        [BindProperty]
        public Prodavac Ja { get; set; }         
        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}

        public string getUserString(string param)
        {
            return HttpContext.Session.GetString(param);
        }
        public async Task<ActionResult> OnGet(int? pageIndex)
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
        public async Task<ActionResult> OnPostObrisiAsync(int id)
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
