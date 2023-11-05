using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Application.Services;
using InTime.Keys.Infrastructure.Refit.Interfaces;
using InTime.Keys.Infrastructure.Services;
using InTime.Keys.Infrastructure.Services.BackgroundServices;
using InTime.Keys.Infrastructure.Services.BidServices;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace InTime.Keys.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddInTimeClient();
            //services.AddAutoBidService();
            services.AddServices();
        }

        static void AddInTimeClient(this IServiceCollection services)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            services.AddRefitClient<IInTimeClient>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://test.intime.kreosoft.space/api/web/"));
        }

        private static void AddAutoBidService(this IServiceCollection services)
        {
            services.AddHostedService<ProfessorAutoBindService>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IKeysCreateService, KeysCreateService>();
            services.AddTransient<IBidService, BidService>();
        }
    }
}
