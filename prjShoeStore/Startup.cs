using Core.Payments.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using prjShoeStore.ConfigExtentions;
using prjShoeStore.Respositories.Infractures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static string WWWROOTPATH { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepository();
            services.AddJwtAuthentication(Configuration);
            services.AddPayPal(option =>
            {
                option.ClientId = "AWTO4yApuMEFaiwvpojaDAZbCinT0fGo0VnaOrAoBwb9e2e_3ce13cIgc593rbmyjWc8RqO20qZzo6-s";
                option.ClientSecret = "ENkbtcmphfnhPh_ZPyVBiLvtNrv5ENS65kkEtEuJkk3gajYDxps-uTJ8UWR0T5dLuZBfjcC-8KySdGIa";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            WWWROOTPATH = Path.Combine(env.ContentRootPath, "wwwroot");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseJwtAthentication();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(name: "default", pattern: "api/{controller}/{action}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
