using AssetManager.Data.Repositories;
using AssetManager.Data.RepositoriesInterface;
using AssetManager.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AssetManager.Config {

    public static class ServiceConfigExtensions {
    
        public static void ConfigureRepositories(this IServiceCollection services) {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountMoveRepository, AccountMoveRepository>();
            services.AddScoped<IAccountMoveLineRepository, AccountMoveLineRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
        }

        public static void ConfigureModelServices(this IServiceCollection services) {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountTypeService, AccountTypeService>();
        }
    }
}