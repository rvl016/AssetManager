using AssetManager.Data.Repositories;
using AssetManager.Data.RepositoriesInterface;
using Microsoft.Extensions.DependencyInjection;


namespace AssetManager.Config {

    public static class ServiceRepositoryConfigExtensions {
    
        public static void ConfigureRepositories(this IServiceCollection services) {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountMoveRepository, AccountMoveRepository>();
            services.AddScoped<IAccountMoveLineRepository, AccountMoveLineRepository>();
        }
    }
}