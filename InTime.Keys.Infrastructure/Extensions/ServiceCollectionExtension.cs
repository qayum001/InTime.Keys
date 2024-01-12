using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Application.Interfaces.Services.KeyServices;
using InTime.Keys.Application.Services;
using InTime.Keys.Infrastructure.Refit.AccountClientConfigurations;
using InTime.Keys.Infrastructure.Refit.Interfaces;
using InTime.Keys.Infrastructure.Services;
using InTime.Keys.Infrastructure.Services.BackgroundServices;
using InTime.Keys.Infrastructure.Services.BidServices;
using InTime.Keys.Infrastructure.Services.EmailServices;
using InTime.Keys.Infrastructure.Services.KeyServices;
using InTime.Keys.Infrastructure.Services.UserServices.UserSeachService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Core;
using Org.BouncyCastle.Bcpg;
using Refit;
using System.Runtime.CompilerServices;

namespace InTime.Keys.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInTimeClient();
            services.AddServices();
            services.AddEmailServices(configuration);
            //services.AddAccauntClient();
        }

        static void AddInTimeClient(this IServiceCollection services)
        {
            var refitSettings = new RefitSettings();

            services.AddRefitClient<IInTimeClient>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://test.intime.kreosoft.space/api/web/"));
        }

        static void AddAccauntClient(this IServiceCollection services)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            services.AddRefitClient<IAccountClient>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://accounts.tsu.ru/api/profile/"));
        }

        private static void AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISmtpClientFabric, SmtpClientFabric>();
            services.AddSingleton<IBaseEmailService, BaseEmailService>();
        }

        private static void AddAutoBidService(this IServiceCollection services)
        {
            services.AddHostedService<ProfessorAutoBindService>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IKeysCreateService, KeysCreateService>();
            services.AddTransient<IBookerBidService, BookerBidService>();
            services.AddTransient<IBidControlService, BidControlService>();
            services.AddTransient<IKeyGetService, KeyService>();
            services.AddTransient<IUserSearchService, UserSearchService>();
            services.AddTransient<IKeyTransferService, KeyTransferService>();
        }
    }
}
