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

            //---> Incluindo o serviço CORS
            //
            services.AddCors();

            // ---> Incluindo configurações do Identity
            //
            services.AddIdentityConfiguration(Configuration);

            //---> Padrão web api e usando Pascal case
            //
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore          
            );

            //---> Adicionando AutoMapper
            //
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

        //---> This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
              app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));

            app.UseRouting();

            //---> Configura o CORS
            //
            //app.UseCors(opt => opt.WithOrigins("http://localhost:8080", "http://localhost:50214")
            //.WithMethods("GET", "POST", "DELETE")
            //);                                
            app.UseCors(opt => opt.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());

            //---> habilita a autenticação.
            //
            app.UseAuthentication();

            //---> middleware que habilita a autorização
            //
            //app.UseAuthorization();

            //---> Adiciona os middleware que executa os end points
            //
            app.UseEndpoints(endpoints =>
            {
                //---> adiciona os end points para as actions dos controladores
                //---> sem especificar rotas
                //
                endpoints.MapControllers();
            });

            app.UseWelcomePage();

            //---> Always verify the container
            //
            //_containerIoC.Verify();
        }
    }
}
