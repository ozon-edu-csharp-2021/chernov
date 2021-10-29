using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next) { }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            var name = Assembly.GetExecutingAssembly().GetName().Name ?? "no name";
            

            var infoObject = new
            {
                Version = version,
                ServiceName = name
            };
            var info = JsonSerializer.Serialize(infoObject);
            await context.Response.WriteAsync(info);
        }
    }
}