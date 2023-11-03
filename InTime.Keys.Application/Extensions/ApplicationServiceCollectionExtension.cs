using InTime.Keys.Application.Dispatcher;
using InTime.Keys.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InTime.Keys.Application.Extensions;

public static class ApplicationServiceCollectionExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediator();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
    }
}