﻿using Contracts;
using Contracts.Helpers;
using Entities.Helpers;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration (this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            { });
        }

        public static void ConfigureLoggerService( this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper( this IServiceCollection services)
        {
            services.AddScoped<ISortHelper<Owner>, SortHelper<Owner>>();
            services.AddScoped<ISortHelper<Account>, SortHelper<Account>>();


            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
