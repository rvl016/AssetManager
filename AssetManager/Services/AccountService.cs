using AssetManager.Data.RepositoriesInterface;
using AssetManager.Models.Accounting;


namespace AssetManager.Services {

    public class AccountService : CrudService<Account>, IAccountService {

        public AccountService(IAccountRepository repository) : base(repository) {}

    }

    public interface IAccountService : ICrudService<Account> {}
}