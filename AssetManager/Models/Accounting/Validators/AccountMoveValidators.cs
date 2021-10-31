using System.ComponentModel.DataAnnotations;
using AssetManager.Models.Accounting;

namespace AssetManager.Models.Validators {

    public class PostedBalanceZeroAttribute : ValidationAttribute {
    
        protected override ValidationResult IsValid(
            object _, ValidationContext validationContext
        ) {
            var move = (AccountMove) validationContext.ObjectInstance;

            if (move.State == AccountMoveState.Posted && ! move.IsBalanced)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
    
}