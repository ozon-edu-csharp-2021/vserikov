using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OzonEdu.MerchandiseService.Main.Infrastructure.Filters;
using OzonEdu.MerchandiseService.Main.Infrastructure.StartupFilters;
using OzonEdu.MerchandiseService.Main.Services.Interfaces;
using OzonEdu.MerchandiseService.Main.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Main.Infrastructure.Interceptors;

namespace OzonEdu.MerchandiseService.Main.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSingleton<IMerchService, MerchService>();

                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());

                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "OzonEdu.MerchandiseService", Version = "v1" });
                    options.CustomSchemaIds(x => x.FullName);
                });
            });

            return builder;
        }
    }
}
