
using System.ComponentModel.DataAnnotations;
using AssetManager.Data.Base;
using AssetManager.Data.RepositoriesInterface;
using AssetManager.Models.Accounting;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Data.Repositories {

    public class AccountMoveRepository : 
        BaseRepository<AccountMove>, IAccountMoveRepository
    {
        public AccountMoveRepository(AssetManagerDbContext dbContext) : base(dbContext) {}

        protected override DbSet<AccountMove> Records => _dbContext.AccountMoves;

        public override void ValidateDeletion(AccountMove move) {
            if (move.State == AccountMoveState.Posted)
                throw new ValidationException("A Posted Journal Item cannot be removed!");
        }
        
    }
}