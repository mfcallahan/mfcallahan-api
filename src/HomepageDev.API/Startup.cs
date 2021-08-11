using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using HomepageDev.API.Bing;
using HomepageDev.API.Interfaces;
using HomepageDev.Models.Options;

namespace HomepageDev.API
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private const string ApiVersion = "v2";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSwagger(services);
            
            services.AddCors();
            services.AddControllers();

            // Configure all dependencies to be injected

            // Use the Options Pattern described here to provide strongly typed access to groups of related settings in appsettings.json:
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0
            services.Configure<AppOptions>(options => Configuration.GetSection("AppSettings:AppOptions").Bind(options));

            // In the Development environment, use .NET Secret Manager to retrieve sensitive information which is not
            // stored in a config file, such as API keys. In the Production environment, these values are stored in the App Service
            // application settings as environment variables.
            // https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0
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
                c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", "mfcallahan-API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            // app.UseAuthorization();
            app.UseCors(
                options => options.WithOrigins("https://mfcallahan.github.io").AllowAnyMethod()
            );
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        // Configure auto-generated Swagger API documentation page
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = ApiVersion,
                    Title = "mfcallahan-API",
                    Description = "A demo API built with ASP.NET 5",
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
        }
    }
}
