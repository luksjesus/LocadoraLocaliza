using AutoMapper;
using Locadora.Application.ViewModels;
using Locadora.Domain.Models;

namespace Locadora.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Locacao, LocacaoViewModel>().ReverseMap();
            CreateMap<ItemLocacao, ItemLocacaoViewModel>().ReverseMap();
            CreateMap<Midia, MidiaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
