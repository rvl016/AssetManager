using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AssetManager.Models.Base;
using AssetManager.Utils;

namespace AssetManager.Models.Accounting
{

    [Index(nameof(Code))]
    public class Account : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(50)]
        public virtual AccountType Type { get; set; }

        [InverseProperty(nameof(AccountMoveLine.Account))]
        public virtual ICollection<AccountMoveLine> MoveLines { get; set; } 
            = new HashSet<AccountMoveLine>();

    }

    public class AccountType : Enumeration
    {

        public static readonly AccountType Asset = new AccountType(1, "Asset");
        public static readonly AccountType Liability = new AccountType(2, "Liability");
        public static readonly AccountType Revenue = new AccountType(3, "Revenue");
        public static readonly AccountType Expense = new AccountType(4, "Expense");

        protected AccountType(int id, string label) : base(id, label) {}
    }

}