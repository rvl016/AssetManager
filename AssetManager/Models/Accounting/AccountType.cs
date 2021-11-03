using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AssetManager.Models.Base;
using AssetManager.Utils;

namespace AssetManager.Models.Accounting
{

    [Index(nameof(Name), IsUnique = true)]
    public class AccountType : BaseEntity {

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public virtual AccountTypeSelection Type { get; set; }

        [InverseProperty(nameof(Account.Type))]
        public virtual ICollection<Account> Accounts { get; set; } = new HashSet<Account>();

    }

    public class AccountTypeSelection : Enumeration {

        public static readonly AccountTypeSelection Asset = 
            new AccountTypeSelection(1, "Asset");
        public static readonly AccountTypeSelection Liability = 
            new AccountTypeSelection(2, "Liability");
        public static readonly AccountTypeSelection Revenue = 
            new AccountTypeSelection(3, "Revenue");
        public static readonly AccountTypeSelection Expense = 
            new AccountTypeSelection(4, "Expense");

        protected AccountTypeSelection(int id, string label) : base(id, label) {}

        public static explicit operator string(AccountTypeSelection at) => at.Label;

    }

}
