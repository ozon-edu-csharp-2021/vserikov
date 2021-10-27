using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogResponse(context);
            await _next(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Response.ContentLength > 0)
                {
                    var buffer = new byte[context.Response.ContentLength.Value];
                    await context.Response.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
                    var body = Encoding.UTF8.GetString(buffer);

                    _logger.LogInformation($"Response: {body}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
            }
        }
    }
}
