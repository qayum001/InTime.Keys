using InTime.Keys.Infrastructure.Refit.Interfaces;
using InTime.Keys.Infrastructure.Services.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace InTime.Keys.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddInTimeClient();
            services.AddAutoBidService();
        }

        static void AddInTimeClient(this IServiceCollection services)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            services.AddRefitClient<IInTimeClient>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://test.intime.kreosoft.space/api/web/"));
        }

        static void AddAutoBidService(this IServiceCollection services)
        {
            services.AddHostedService<ProfessorAutoBindService>();
        }
    }
}
