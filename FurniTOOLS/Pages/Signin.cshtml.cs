using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS
{
    public class SigninModel : PageModel
    {

        [BindProperty]
        public string Firma { get; set; }
        [BindProperty]
        public int KorisnikID { get; set; }
        
        [BindProperty]
        public Prodavac Prodavac { get; set; }
        public string ErrorMessage { get; set; }
        [BindProperty]
        public int Type { get; set; }
        public void OnGet()
        {
        }
        private readonly AppContext _db;
        public SigninModel(AppContext db)
        {
            _db=db;
            ErrorMessage="";
        }
        public async Task<IActionResult> OnPostSignup()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
        }
    }
}
