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
using SimpleInjector;

namespace Locadora.WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        // private Container _containerIoC = new SimpleInjector.Container();
        // private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public Startup(IConfiguration configuration)
        {
            //---> Set to false. This will be the default in v5.x and going forward.
            //
            //_containerIoC.Options.ResolveUnregisteredConcreteTypes = false;

            Configuration = configuration;
        }

        //---> This method gets called by the runtime. Use this method to add services to the container.
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

            //---> Adicionando Context para conexão com o banco de dados.
            //
            //.UseLoggerFactory(_logger).EnableSensitiveDataLogging()
            services.AddDbContext<LocadoraContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("LocadoraConnectionDev")));


            /*
            #if DEBUG
            services.AddDbContext<LocadoraContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocadoraConnectionDev")).UseLoggerFactory(_logger).EnableSensitiveDataLogging()
                );
            #else
                services.AddDbContext<LocadoraContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LocadoraConnection")));
            #endif
            */





            //---> Adicionando SimpleInjector
            //
            SimpleInjectionBootstrapper.Register(services);
            /*
            services.AddSimpleInjector(_containerIoC, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    // All calls are optional. You can enable what you need. For instance,
                    // PageModels and TagHelpers are not needed when you build a Web API.
                    .AddControllerActivation()
                    .AddViewComponentActivation();
                    //.AddPageModelActivation()
                    //.AddTagHelperActivation();

                // Optionally, allow application components to depend on the non-generic
                // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
                //options.AddLocalization();
            });
            */

            //---> Registrando Classes no SimpleInjector
            //
            // SimpleInjectionBootstrapper.Register(_containerIoC);
        }

        //---> This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //---> UseSimpleInjector() finalizes the integration process.
            //
            //app.UseSimpleInjector(_containerIoC);

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
                        
            //---> middleware de roteamento
            //
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
