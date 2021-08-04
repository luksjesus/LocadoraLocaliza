using Locadora.WebApi.Data;
using Locadora.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Locadora.WebApi.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            #if DEBUG
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("LocadoraConnectionDev")));
#else
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("LocadoraConnection")));
#endif



            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                // options.Password.RequireUppercase = true;
                // options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._ @";
                options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //JWT
            //adiciona o manipulador de autenticacao e define o 
            //esquema de autenticacao usado : Bearer
            //valida o emissor, a audiencia e a chave
            //usando a chave secreta valida a assinatura
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                // x.SaveToken = true;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // ValidateIssuer = true,
                    ValidateIssuer = false,
                    // ValidateAudience = true,
                    ValidateAudience = false,
                    // ValidAudience = appSettings.ValidoEm,
                    // ValidIssuer = appSettings.Emissor
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            
            /*
            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidAudience = configuration["TokenConfiguration:Audience"],
                     ValidIssuer = configuration["TokenConfiguration:Issuer"],
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
                 });
                */

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            return services;
        }
    }
}
