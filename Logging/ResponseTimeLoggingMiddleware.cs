using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleWebApp.Logging
{
    public class ResponseTimeLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseTimeLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();

            context.Response.OnStarting(state => {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("X-Response-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
                return Task.CompletedTask;
            }, context);

            await _next(context);
        }
    }

    public static class ResponseTimeLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseTimeLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseTimeLoggingMiddleware>();
        }
    }

}
