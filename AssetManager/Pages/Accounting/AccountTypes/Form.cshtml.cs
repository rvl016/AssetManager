using System;
using System.Collections.Generic;
using System.Linq;
using AssetManager.Models.Accounting;
using AssetManager.Services;
using AssetManager.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManager.Pages {

    public class AccountTypeFormModel : PageModel {


        [BindProperty(SupportsGet = true)]
        public int AccountTypeId { get; set; }

        [BindProperty]
        public AccountType AccountType { get; set; }

        [BindProperty]
        public String AccountTypeSelectionLabel { get; set; }

        private readonly IAccountTypeService _accountTypeService;

        public List<SelectListItem> AccountTypesSelection { get; set; } 

        public AccountTypeFormModel(IAccountTypeService accountService) {
            _accountTypeService = accountService;
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context) {
            base.OnPageHandlerExecuting(context);

            ViewData["Title"] = "Account Type";
        }

        public void OnGet() {
            if (AccountTypeId != 0)
                AccountType = _accountTypeService.GetById(AccountTypeId);

            SetUpFormData(); 
        }

        public IActionResult OnPost() {

            if (! ModelState.IsValid) {
                SetUpFormData(); 
                return Page();
            }

            using (_accountTypeService)
                _accountTypeService.CreateOrUpdate(AccountType);

            return RedirectToPage("./List");
        }

        private void SetUpFormData() {
            AccountTypesSelection = AccountTypeSelection.GetAll<AccountTypeSelection>().Select(
                (type) => new SelectListItem(
                    type.Label, type.Label, (AccountType?.Type.Label ?? "") == type.Label
                )
            ).ToList();
        }

    }
}
