using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AssetManager.Models.Base;
using AssetManager.Utils;

namespace AssetManager.Models.Accounting
{

    [Index(nameof(Code), IsUnique = true)]
    public class Account : BaseEntity {

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public virtual AccountType Type { get; set; }

        [InverseProperty(nameof(AccountMoveLine.Account))]
        public virtual ICollection<AccountMoveLine> MoveLines { get; set; } 
            = new HashSet<AccountMoveLine>();

    }

}