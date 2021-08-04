using AutoMapper;
using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class ItemLocacaoAppService : IItemLocacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly IItemLocacaoRepository _ItemLocacaoRepository;
        private readonly IItemLocacaoService _ItemLocacaoService;
        private readonly LocadoraContext _context;

        public ItemLocacaoAppService(IItemLocacaoRepository ItemLocacaoRepository,
                                       IMapper mapper,
                                       IItemLocacaoService ItemLocacaoService,
                                       LocadoraContext context)
        {
            _ItemLocacaoRepository = ItemLocacaoRepository;
            _ItemLocacaoService = ItemLocacaoService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ItemLocacaoViewModel> GetById(Guid id)
        {
            return _mapper.Map<ItemLocacaoViewModel>(await _ItemLocacaoRepository.GetById(id));
        }

        public async Task<ItemLocacaoViewModel> GetByIdNoTracking(Guid id)
        {
            return _mapper.Map<ItemLocacaoViewModel>(await _ItemLocacaoRepository.GetByIdNoTracking(id));
        }

        public async Task<IEnumerable<ItemLocacaoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ItemLocacaoViewModel>>(await _ItemLocacaoRepository.GetAll());
        }

        public async Task Add(ItemLocacaoViewModel ItemLocacaoViewModel)
        {
            var ItemLocacao = _mapper.Map<ItemLocacao>(ItemLocacaoViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _ItemLocacaoService.Add(ItemLocacao);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Update(ItemLocacaoViewModel ItemLocacaoViewModel)
        {
            var ItemLocacao = _mapper.Map<ItemLocacao>(ItemLocacaoViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _ItemLocacaoService.Update(ItemLocacao);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var transacao = _context.Database.BeginTransaction())
            {
                _ItemLocacaoService.Delete(id);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public void Dispose()
        {
            _ItemLocacaoService.Dispose();
        }
    }
}
