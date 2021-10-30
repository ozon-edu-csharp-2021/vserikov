using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var result = new
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version",
                ServiceName = Assembly.GetExecutingAssembly().GetName().Name?.ToString() ?? "no name"
            };

            var json = JsonConvert.SerializeObject(result);
            await context.Response.WriteAsync(json);
        }
    }
}
