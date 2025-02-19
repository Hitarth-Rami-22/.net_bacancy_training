using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogRequest
    {
        private readonly RequestDelegate _next;

        public LogRequest(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.Write("Request/LogRequest: ");
            Console.Write(DateTime.Now.ToString("HH:mm:ss.ffff"));

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogRequestExtensions
    {
        public static IApplicationBuilder UseLogRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequest>();
        }
    }
}
