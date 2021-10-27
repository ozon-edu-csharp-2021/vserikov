using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Main.Infrastructure.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());

                app.UseMiddleware<RequestLoggingMiddleware>();
                //app.UseMiddleware<ResponseLoggingMiddleware>();

                next(app);
            };
        }
    }
}
