using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Infrastructure.Middlewares
{
    public class ReadyMiddleware
    {
        public ReadyMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var x = HttpStatusCode.OK;
            await context.Response.WriteAsync(StatusCodes.Status200OK.ToString());
            await context.Response.WriteAsync(x.ToString());
        }
    }
}
