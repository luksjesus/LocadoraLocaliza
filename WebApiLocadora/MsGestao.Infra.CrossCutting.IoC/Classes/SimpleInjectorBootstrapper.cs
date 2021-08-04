using Locadora.Application.Interfaces;
using Locadora.Application.Services;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Notificador;
using Locadora.Domain.Services;
using Locadora.Infra.Data.Context;
using Locadora.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Infra.CrossCutting.IoC.Classes
{
    public class SimpleInjectionBootstrapper
    {
        // Lifestyle.Transient => Uma instancia unica para o request não guarda estado e é leve
        // Lifestyle.Singleton => Uma instancia unica independente da requisição.
        // Lifestyle.Scoped    => Uma instancia unica para o request e guarda estado
        public static void Register(IServiceCollection services)        
        {
            //---> Camada de Aplicação
            //
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IItemLocacaoAppService, ItemLocacaoAppService>();
            services.AddScoped<ILocacaoAppService, LocacaoAppService>();
            services.AddScoped<IMidiaAppService, MidiaAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            //---> Camada de Dominio
            //
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IItemLocacaoService, ItemLocacaoService>();
            services.AddScoped<IItemLocacaoRepository, ItemLocacaoRepository>();

            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();

            services.AddScoped<IMidiaService, MidiaService>();
            services.AddScoped<IMidiaRepository, MidiaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<INotificador, Notificador>();

            //---> Camada de Infra
            //
            services.AddScoped<LocadoraContext>();
        }
    }
}

