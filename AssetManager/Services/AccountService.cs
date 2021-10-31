using System.Collections.Generic;
using AssetManager.Data.Base;
using AssetManager.Models.Accounting;


namespace AssetManager.Services {

    public class AccountService : CrudService<Account> {

        public AccountService(IRepository<Account> repository) : base(repository) {}

        

    }
}