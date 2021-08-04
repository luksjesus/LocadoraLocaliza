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
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly IProdutoService _ProdutoService;
        private readonly LocadoraContext _context;

        public ProdutoAppService(IProdutoRepository ProdutoRepository,
                                       IMapper mapper,
                                       IProdutoService ProdutoService,
                                       LocadoraContext context)
        {
            _ProdutoRepository = ProdutoRepository;
            _ProdutoService = ProdutoService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ProdutoViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _ProdutoRepository.GetById(id));
        }

        public async Task<ProdutoViewModel> GetByIdNoTracking(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _ProdutoRepository.GetByIdNoTracking(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetByName(string nome)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _ProdutoRepository.GetByName(nome));
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _ProdutoRepository.GetAll());
        }

        public async Task Add(ProdutoViewModel ProdutoViewModel)
        {
            var Produto = _mapper.Map<Produto>(ProdutoViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _ProdutoService.Add(Produto);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Update(ProdutoViewModel ProdutoViewModel)
        {
            var Produto = _mapper.Map<Produto>(ProdutoViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _ProdutoService.Update(Produto);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var transacao = _context.Database.BeginTransaction())
            {
                _ProdutoService.Delete(id);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public void Dispose()
        {
            _ProdutoService.Dispose();
        }
    }
}
