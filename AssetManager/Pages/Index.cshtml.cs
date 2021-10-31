using AssetManager.Models.Accounting;
using AssetManager.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AssetManager.Pages
{

    public class IndexModel : PageModel
    {

        public List<SelectListItem> AccountTypesSelection => 
            AccountTypeSelection.GetAll<AccountTypeSelection>().Select(
                (type) => new SelectListItem(type.Label, type.Label)
            ).ToList();

        public string DayName { get; private set; }

        public DbSet<Account> Accounts => _db.Accounts;

        [BindProperty]
        public Account Account { get; private set; }

        public string AccountTypeInContext { get; private set; }

        private AssetManagerDbContext _db;

        public IndexModel(AssetManagerDbContext dbContext) {
            _db = dbContext;
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context) {
            ViewData["Title"] = "Home";
        }

        public void OnGet()
        {

            DayName = DateTime.Now.ToString("dddd");
        }

        public IActionResult OnPost()
        {
            if (! ModelState.IsValid) 
                return Page();
            _db.Accounts.Add(Account);
            _db.SaveChanges();
            return RedirectToPage("/Index");
        }
    }

}
