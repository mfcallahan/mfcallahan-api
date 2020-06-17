using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace HomepageDev
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string apiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new OpenApiInfo
                {
                    Version = apiVersion,
                    Title = "mfcallahan-dev API",
                    Description = "A demo ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Matthew Callahan",
                        Email = "matthew.callahan@outlook.com",
                        Url = new Uri("https://mfcallahan.com"),
                    }
                    //TODO: add license to repo and update this
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Use under LICX",
                    //    Url = new Uri("https://example.com/license"),
                    //}
                });
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllers();
            services.AddMvcCore().AddRazorViewEngine();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            const string swaggerRoutePrefix = "api";
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{swaggerRoutePrefix}/swagger/{apiVersion}/swagger.json", "mfcallahan-dev API");
                c.RoutePrefix = swaggerRoutePrefix;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
