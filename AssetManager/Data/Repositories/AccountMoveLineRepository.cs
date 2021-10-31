using System.ComponentModel.DataAnnotations;
using AssetManager.Data.Base;
using AssetManager.Data.RepositoriesInterface;
using AssetManager.Models.Accounting;
using Microsoft.EntityFrameworkCore;


namespace AssetManager.Data.Repositories {

    public class AccountMoveLineRepository : 
        BaseRepository<AccountMoveLine>, IAccountMoveLineRepository
    {
        public AccountMoveLineRepository(AssetManagerDbContext dbContext) : base(dbContext) {}

        protected override DbSet<AccountMoveLine> Records => _dbContext.AccountMoveLines;

        public override void ValidateDeletion(AccountMoveLine moveLine) {
            if (moveLine.Move != null && moveLine.Move.State == AccountMoveState.Posted)
                throw new ValidationException("A Posted Journal Item cannot be removed!");
        }
        
    }
}