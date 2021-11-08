using System.Collections.Generic;
using AssetManager.Models.Accounting;
using AssetManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AssetManager.Pages
{

    public class AccountFormModel : PageModel
    {


        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }

        [BindProperty]
        public Account Account { get; set; }

        private readonly IAccountService _accountService;

        public AccountFormModel(IAccountService accountService) {
            _accountService = accountService;
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context) {
            ViewData["Title"] = "Accounts";

        }

        public void OnGet() {
            if (AccountId != 0)
                Account = _accountService.GetById(AccountId);
        }

        public IActionResult OnPost() {
            if (! ModelState.IsValid) 
                return Page();

            using (_accountService)
                _accountService.CreateOrUpdate(Account);
                
            return RedirectToPage("./List");
        }
    }
}
