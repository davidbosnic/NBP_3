using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WEBFurniTOOLS.Pages.KupacRP
{
    public class KupovinaModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public double CenaDO { get; set; }
        [BindProperty(SupportsGet=true)]
        public double CenaOD { get; set; }
        [BindProperty(SupportsGet=true)]
        public bool Cena { get; set; }
        [BindProperty]
        public Kupac Ja { get; set; }
        public int? idKupac { get; set; }
        public List<Prodavac> Prodavci { get; set; }
        public List<Proizvod> Proizvodi { get; set; }
        public SelectList ImenaProizvoda { get; set; }
        public SelectList ImenaFirmi { get; set; }
        public PaginatedList<Proizvod> ListaZaPrikaz { get; set; }
        [BindProperty (SupportsGet=true)]
        public string? Search1 {get; set;}

        [BindProperty (SupportsGet=true)]
        public string? Search3 {get; set;}        
        private AppContext _db { get; set; }
        [BindProperty]
        public int pageInput{get;set;}

        [BindProperty]

        public int pageSize{get;set;}
        public KupovinaModel(AppContext db){
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
        public async Task<IActionResult> OnPostPretrazi()
        {

        }
        public double MaxCena()
        {
            double max = 0;
            foreach (var item in Proizvodi)
            {
                if(item.CenaPoKomadu>max)
                    max=item.CenaPoKomadu;
            }
            return max;
        }
        public async Task<ActionResult> OnPostIzlogujSe()
        {

        }
    }
}
