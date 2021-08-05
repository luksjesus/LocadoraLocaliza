using AutoMapper;
using Locadora.Application.AutoMapper;
using Locadora.Infra.CrossCutting.IoC.Classes;
using Locadora.Infra.Data.Context;
using Locadora.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SimpleInjector;

namespace Locadora.WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }          

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors();

            services.AddIdentityConfiguration(Configuration);

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore          
            );

            MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

            services.AddSwaggerGen(c =>
            {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
            });
            
            services.AddDbContext<LocadoraContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("LocadoraConnectionDev")));

            SimpleInjectionBootstrapper.Register(services);           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
              app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));

            app.UseRouting();

                                  
            app.UseCors(opt => opt.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
      
            app.UseAuthentication();

     
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseWelcomePage();            
        }
    }
}
