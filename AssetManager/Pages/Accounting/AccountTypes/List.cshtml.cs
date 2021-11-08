using System.Collections.Generic;
using AssetManager.Models.Accounting;
using AssetManager.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AssetManager.Pages
{

    public class AccountTypeListModel : PageModel
    {


        public IEnumerable<AccountType> AccountTypes { get; private init; }

        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeListModel(IAccountTypeService accountTypeService) {
            _accountTypeService = accountTypeService;
            AccountTypes = _accountTypeService.GetAll();
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context) {
            ViewData["Title"] = "Account Types";
        }

    }
}