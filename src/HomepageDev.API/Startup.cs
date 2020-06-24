using HomepageDev.API;
using HomepageDev.API.Interfaces;
using HomepageDev.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
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
        private readonly Container Container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
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

            //services.AddSimpleInjector(Container, options => options.AddAspNetCore().AddControllerActivation());

            //InitializeContainer();

            services.AddSingleton<IAppSettings>(new AppSettings {
                BingApiRootUrl = Configuration.GetValue<string>("AppSettings:Geocode:Bing:ApiRootUrl"),
                BingApiKey = Configuration.GetValue<string>("AppSettings:Geocode:Bing:ApiKey"),
                BingGeocodeSingleAddressEndpoint = Configuration.GetValue<string>("AppSettings:Geocode:Bing:GeocodeSingleAddressEndpoint")
            });
            services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();
            services.AddSingleton<IBingGeocoder, BingGeocoder>();
        }

        private void InitializeContainer()
        {
            Container.Register<IAppSettings, IAppSettings>(Lifestyle.Singleton);
            Container.RegisterInitializer<IAppSettings>(appSettings => {
                appSettings.BingApiRootUrl = Configuration.GetValue<string>("AppSettings:Geocode:Bing:ApiRootUrl");
                appSettings.BingApiKey = Configuration.GetValue<string>("AppSettings:Geocode:Bing:ApiKey");
                appSettings.BingGeocodeSingleAddressEndpoint = Configuration.GetValue<string>("AppSettings:Geocode:Bing:GeocodeSingleAddressEndpoint");
            });

            Container.Register<IHttpClientWrapper, HttpClientWrapper>(Lifestyle.Singleton);
            Container.Register<IBingGeocoder, BingGeocoder>(Lifestyle.Singleton);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
