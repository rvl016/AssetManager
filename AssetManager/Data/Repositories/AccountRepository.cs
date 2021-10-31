using System.ComponentModel.DataAnnotations;
using AssetManager.Data.Base;
using AssetManager.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AssetManager.Data.RepositoriesInterface;

namespace AssetManager.Data.Repositories {

    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AssetManagerDbContext dbContext) : base(dbContext) {}

        protected override DbSet<Account> Records => _dbContext.Accounts;

        public override void ValidateDeletion(Account account) {
            var moves = account.MoveLines.Select(aml => aml.Move).Where(m => m != null).Distinct();
            if (moves.Any(m => m.State == AccountMoveState.Posted))
                throw new ValidationException(
                    "An Account with Posted Journal Entries Cannot be Removed!"
                );
        }
        
    }
}
