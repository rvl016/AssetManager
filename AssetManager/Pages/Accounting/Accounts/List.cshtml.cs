using System.Collections.Generic;
using AssetManager.Models.Accounting;
using AssetManager.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AssetManager.Pages
{

    public class AccountListModel : PageModel
    {


        public IEnumerable<Account> Accounts { get; private init; }

        private readonly IAccountService _accountService;

        public AccountListModel(IAccountService accountService) {
            _accountService = accountService;
            Accounts = _accountService.GetAll();
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context) {
            ViewData["Title"] = "Accounts";
        }

    }
}