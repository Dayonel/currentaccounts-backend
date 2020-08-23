using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CurrentAccounts.Extensions
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CurrentAccounts API", Version = "v1" });
            });
        }
    }
}
