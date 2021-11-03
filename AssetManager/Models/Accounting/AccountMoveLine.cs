using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AssetManager.Models.Base;
using AssetManager.Models.Validators;

namespace AssetManager.Models.Accounting
{

    public class AccountMoveLine : BaseEntity
    {

        public virtual int MoveId { get; set; }

        [Required]
        [ForeignKey("MoveId")]
        public virtual AccountMove Move { get; set; }

        public virtual int AccountId { get; set; }

        [Required]
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Column(TypeName = "decimal(21, 8)")]
        [Range(0, double.PositiveInfinity)]
        public virtual decimal Debit { get; set; } = .0M;

        [Column(TypeName = "decimal(21, 8)")]
        [Range(0, double.PositiveInfinity)]
        [EitherCreditDebit]
        public virtual decimal Credit { get; set; } = .0M;

    }


}
