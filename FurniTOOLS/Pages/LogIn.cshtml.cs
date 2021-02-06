using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FurniTOOLS.Models;
using MongoDB.Driver;

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
        private readonly IMongoCollection<Administrator> _db;
        public LogInModel(IAdminDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _db = database.GetCollection<Administrator>(settings.AdminsCollectionName);
            Message ="";
        }
        public async Task<IActionResult> OnPostLogin()
        {
            return Page();
        }
    }
}
