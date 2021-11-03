using System.ComponentModel.DataAnnotations;
using AssetManager.Data.Base;
using AssetManager.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AssetManager.Data.RepositoriesInterface;

namespace AssetManager.Data.Repositories {

    public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(AssetManagerDbContext dbContext) : base(dbContext) {}

        protected override DbSet<AccountType> Records => _dbContext.AccountTypes;

        public override void ValidateDeletion(AccountType accountType) {
            if (accountType.Accounts.Count > 0)
                throw new ValidationException(
                    "An Account Type with associated accounts cannot be deleted!"
                );
        }
        
    }
}

