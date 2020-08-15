using HomepageDev.API;
using HomepageDev.API.Interfaces;
using HomepageDev.Models.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace HomepageDev
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string ApiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Swagger documentation page
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = ApiVersion,
                    Title = "mfcallahan-dev API",
                    Description = "A demo API built with ASP.NET Core",
                    Contact = new OpenApiContact
                    {
                        Name = "Matthew Callahan",
                        Email = "matthew.callahan@outlook.com",
                        Url = new Uri("https://mfcallahan.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/mfcallahan/mfcallahan-dev/blob/master/LICENSE"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            // Configure all dependencies to be injected

            // Use the Options Pattern described here to provide strongly typed access to groups of related settings in appsettings.json:
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1
            services.Configure<AppOptions>(options => Configuration.GetSection("AppSettings:AppOptions").Bind(options));

            // Also use .NET Core Secret Manager to retreive sensitive information that is not stored in a config file, such as API keys:
            // https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1
            services.Configure<BingOptions>(options => {
                Configuration.GetSection("AppSettings:GeocodeOptions:Bing").Bind(options);
                options.ApiKey = Configuration["GeocodeOptions:Bing:ApiKey"];
            });

            services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();
            services.AddScoped<IBingGeocoder, BingGeocoder>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", "mfcallahan-dev API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
