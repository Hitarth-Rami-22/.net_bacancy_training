using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandalingMIddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandalingMIddleware(RequestDelegate next)
        {

            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("Error handaling middleware");
                return _next(httpContext);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured in application");
                Console.WriteLine(ex.Message);
                return null;

            }


           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandalingMIddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandalingMIddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandalingMIddleware>();
        }
    }
}
