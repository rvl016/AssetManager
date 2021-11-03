using AssetManager.Data.RepositoriesInterface;
using AssetManager.Models.Accounting;


namespace AssetManager.Services {

    public class AccountTypeService : CrudService<AccountType>, IAccountTypeService {

        public AccountTypeService(IAccountTypeRepository repository) : base(repository) {}

    }

    public interface IAccountTypeService : ICrudService<AccountType> {}
}
