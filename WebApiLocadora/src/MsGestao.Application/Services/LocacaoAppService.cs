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
    public class LocacaoAppService : ILocacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly ILocacaoRepository _LocacaoRepository;
        private readonly ILocacaoService _LocacaoService;
        private readonly LocadoraContext _context;

        public LocacaoAppService(ILocacaoRepository LocacaoRepository,
                                       IMapper mapper,
                                       ILocacaoService LocacaoService,
                                       LocadoraContext context)
        {
            _LocacaoRepository = LocacaoRepository;
            _LocacaoService = LocacaoService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<LocacaoViewModel> GetById(Guid id)
        {
            return _mapper.Map<LocacaoViewModel>(await _LocacaoRepository.GetById(id));
        }

        public async Task<LocacaoViewModel> GetByIdNoTracking(Guid id)
        {
            return _mapper.Map<LocacaoViewModel>(await _LocacaoRepository.GetByIdNoTracking(id));
        }

        public async Task<IEnumerable<LocacaoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LocacaoViewModel>>(await _LocacaoRepository.GetAll());
        }

        public async Task Add(LocacaoViewModel LocacaoViewModel)
        {
            var Locacao = _mapper.Map<Locacao>(LocacaoViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _LocacaoService.Add(Locacao);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Update(LocacaoViewModel LocacaoViewModel)
        {
            var Locacao = _mapper.Map<Locacao>(LocacaoViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _LocacaoService.Update(Locacao);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var transacao = _context.Database.BeginTransaction())
            {
                _LocacaoService.Delete(id);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public void Dispose()
        {
            _LocacaoService.Dispose();
        }
    }
}
