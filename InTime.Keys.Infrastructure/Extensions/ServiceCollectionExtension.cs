﻿using InTime.Keys.Application.Interfaces.Services.BidServices;
using InTime.Keys.Application.Interfaces.Services.KeyServices;
using InTime.Keys.Application.Services;
using InTime.Keys.Infrastructure.Authorization.Handler;
using InTime.Keys.Infrastructure.Refit.Interfaces;
using InTime.Keys.Infrastructure.Services;
using InTime.Keys.Infrastructure.Services.BackgroundServices;
using InTime.Keys.Infrastructure.Services.BidServices;
using InTime.Keys.Infrastructure.Services.KeyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Runtime.CompilerServices;

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
            services.AddTransient<IBookerBidService, BookerBidService>();
            services.AddTransient<IBidControlService, BidControlService>();
            services.AddTransient<IKeyService, KeyService>();
        }
    }
}
