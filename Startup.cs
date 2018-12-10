using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ASP.NET_CORE_PractSite.Models;

namespace ASP.NET_PractSite
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;

        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                                    .AddEnvironmentVariables()
                                    .AddJsonFile(env.ContentRootPath + "/config.json")
                                    .AddJsonFile(env.ContentRootPath + "/config.development.json", true)
                                    .Build();

        }

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<SpecialsDataContext>();

            services.AddTransient<FormattingService>();

            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                EnableDeveloperExceptions = 
                    configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
            });

            services.AddMvc();
        }

        public void Configure(
                IApplicationBuilder app, 
                IHostingEnvironment env,
                ILoggerFactory loggerFactory,
                FeatureToggles features
                )
        {

            app.UseExceptionHandler("/error.html");



            {
                app.UseDeveloperExceptionPage();
            } 

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                    throw new Exception("ERROR!");

                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                   "{controller=Home}/{action=Index}/{id?}"
                    );
            });
            app.UseFileServer();
        }
    }
}
