using System.Data;
using Core.Utilities.Ioc;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Service.Abstract;
using Service.Concrete;

namespace Service.Modules;

public class DIModule:ICoreModule
{
    private IConfiguration _configuration;

    public DIModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Load(IServiceCollection serviceCollection)
    {
        
        serviceCollection.AddScoped<IDbConnection>(sp
            => new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql")));
        
        serviceCollection.AddScoped<ICategoryService, CategoryManager>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();

        serviceCollection.AddScoped<IAdvertService, AdvertManager>();
        serviceCollection.AddScoped<IAdvertRepository, AdvertRepository>();
        
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserService, UserManager>();
        
        serviceCollection.AddScoped<IOperationClaimService, OperationClaimManager>();
        serviceCollection.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        
        serviceCollection.AddScoped<IAuthService, AuthManager>();
        
        serviceCollection.AddScoped<ITokenHelper, JwtHelper>();
    }
}