using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Application.Interfaces.Repositories.BidRepositories;
using InTime.Keys.Persistence.Contexts.EfCore;
using InTime.Keys.Persistence.Contexts.EfCore.Repositories;
using InTime.Keys.Persistence.Contexts.EfCore.Repositories.BidRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InTime.Keys.Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEfCoreDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddEfCoreDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var conStr = configuration["ConnectionStrings:KeysDb"];
        services.AddSqlServer<ApplicationDbContext>(conStr);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddTransient<IBidListGetRepositiry, BidListGetRepositiry>();
    }
}
