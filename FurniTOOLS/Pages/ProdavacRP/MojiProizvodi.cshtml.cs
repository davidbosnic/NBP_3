using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS.Pages.ProdavacRP
{
    public class MojiProizvodiModel : PageModel
    {
        public AppContext _db{get;set;}
        public int? idProdavac{get;set;}
        [BindProperty]
        public Prodavac Ja { get; set; } 
        public PaginatedList<Proizvod> MojiProizvodi {get;set;}
        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}

        public MojiProizvodiModel(AppContext db)
        {
            _db=db;
            pageInput=1;
        }

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
        public async Task<ActionResult> OnPostObrisiProizvod(int id)
        {
            return Page();
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {
            return Page();
        }
    }
}
