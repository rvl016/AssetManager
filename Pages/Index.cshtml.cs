using AssetManager.Models.Accounting;
using AssetManager.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManager.Pages
{

    public class IndexModel : PageModel
    {

        public List<SelectListItem> AccountTypeSelection => 
            AccountType.GetAll<AccountType>().Select(
                (type) => new SelectListItem(type.Label, type.Label)
            ).ToList();

        public string DayName { get; private set; }

        public DbSet<Account> Accounts { get; private set; }

        [BindProperty]
        public Account Account { get; private set; }

        public string AccountTypeInContext { get; private set; }

        private AssetManagerDbContext _db;

        public IndexModel(AssetManagerDbContext dbContext) {
            _db = dbContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Home";

            DayName = DateTime.Now.ToString("dddd");
            Accounts = _db.Accounts;
        }

        public IActionResult OnPost()
        {
            if (! ModelState.IsValid) {
                OnGet();
                return Page();
            }
            _db.Accounts.Add(Account);
            _db.SaveChanges();
            return RedirectToPage("/Index");
        }
    }

}
