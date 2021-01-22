using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEBFurniTOOLS
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public int Type { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }
        private readonly AppContext _db;
        public LogInModel(AppContext db)
        {
            _db=db;
            Message="";
        }
        public async Task<IActionResult> OnPostLogin()
        {
            
		}
    }
}
