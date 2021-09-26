

using System.ComponentModel.DataAnnotations;
using AssetManager.Models.Accounting;

namespace AssetManager.Models.Validators {

    public class EitherCreditDebitAttribute : ValidationAttribute {
    
        protected override ValidationResult IsValid(
            object _, ValidationContext validationContext
        ) {
            var moveLine = (AccountMoveLine) validationContext.ObjectInstance;

            if (moveLine.Credit != .0M && moveLine.Debit != .0M)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
    
}