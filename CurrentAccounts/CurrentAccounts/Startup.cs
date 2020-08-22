using CurrentAccounts.DI;
using CurrentAccounts.Extensions;
using CurrentAccounts.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CurrentAccounts
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings{(env.IsDevelopment() ? ".Development" : "")}.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region DI
            services.AddDependencies(Configuration);
            #endregion

            #region .Net Core dependencies
            services.AddControllers();
            services.ConfigureSwagger();
            services.AddMvc(x =>
            {
                x.Filters.Add(new ModelStateFilter());
            })
            .ConfigureApiBehaviorOptions(bh =>
            {
                bh.SuppressModelStateInvalidFilter = true;
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                loggerFactory.AddSerilog();
                loggerFactory.AddFile("logs/currentaccountsapi-{Date}.txt", LogLevel.Information);
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrentAccounts API v1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
