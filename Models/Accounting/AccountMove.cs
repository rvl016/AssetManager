using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AssetManager.Models.Base;
using AssetManager.Utils;
using System;
using AssetManager.Models.Validators;

namespace AssetManager.Models.Accounting
{

    public class AccountMove : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public virtual string Reference { get; set; }

        [Required]
        [StringLength(50)]
        [PostedBalanceZero]
        public virtual AccountMoveState State { get; set; } = AccountMoveState.Draft;

        public virtual DateTime? DatePosted { get; set; }

        [InverseProperty(nameof(AccountMoveLine.Move))]
        public virtual ICollection<AccountMoveLine> MoveLines { get; set; } 
            = new HashSet<AccountMoveLine>();

        public decimal Balance => MoveLines.Aggregate(
            .0M, (acc, mv) => acc + mv.Debit - mv.Credit
        );

        public bool IsBalanced => Balance == .0M;

    }

    public class AccountMoveState : Enumeration
    {

        public static readonly AccountMoveState Draft = new AccountMoveState(1, "Unposted");
        public static readonly AccountMoveState Posted = new AccountMoveState(2, "Posted");

        protected AccountMoveState(int id, string label) : base(id, label) {}
    }

}

