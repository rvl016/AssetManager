using AssetManager.Data;
using AssetManager.Models.Accounting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace AssetManager.Pages
{

    public class AccountListModel : PageModel
    {


        public DbSet<Account> Accounts => _db.Accounts;

        private AssetManagerDbContext _db;

        public AccountListModel(AssetManagerDbContext dbContext) {
            _db = dbContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Accounts";
        }

    }
}