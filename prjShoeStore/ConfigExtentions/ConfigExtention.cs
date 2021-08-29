using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using prjShoeStore.Areas.Identity.Data;
using prjShoeStore.Data;
using prjShoeStore.Options;
using prjShoeStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjShoeStore.ConfigExtentions
{
    public static class ConfigExtention
    {
        public static void AddOptionSetting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<JwtSetting>((store) =>
            {
                JwtSetting jwtSetting = new JwtSetting();
                configuration.Bind(nameof(JwtSetting), jwtSetting);
                return jwtSetting;
            });
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>
            (options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContextConnection")))
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddSwaggerGen();


            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                // Use the default property (Pascal) casing.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

                // Configure a custom converter.
                //options.JsonSerializerOptions.Converters.Add(new MyCustomJsonConverter());
            }); 
            JwtSetting jwtSetting = new JwtSetting();
            Configuration.Bind(nameof(JwtSetting), jwtSetting);
            services.AddSingleton<JwtSetting>((store) =>
            {
                
                return jwtSetting;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/Account/Unauthorized/";
               options.AccessDeniedPath = "/Account/Forbidden/";
           })
           .AddJwtBearer(options =>
           {
               //options.Audience = "http://localhost:5001/";
               //options.Authority = "http://localhost:44313/api";
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey))
               };
           });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            return services;
        }
        public static IApplicationBuilder UseJwtAthentication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            // Enable middleware to serve generated Swagger as a JSON endpoint.

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
