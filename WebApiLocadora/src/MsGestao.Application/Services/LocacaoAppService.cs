using AutoMapper;
using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Locadora.Domain.Enum;

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

        public async Task<IEnumerable<LocacaoViewModel>> GetByIdCliente(Guid ClienteId)
        {
            return _mapper.Map<IEnumerable<LocacaoViewModel>>(await _LocacaoRepository.GetByIdCliente(ClienteId));
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

        public async Task<LocacaoViewModel> CalcularTotalPraPagamento(Guid LocacaoId, DateTime DataEntrega)
        {
            var locacao = await _LocacaoRepository.GetById(LocacaoId);
            locacao.DataEntrega = DataEntrega;
            
            var numeroDeDiasEmAtraso = (int)DataEntrega.Subtract(locacao.DataPrevisaoEntrega).TotalDays;

            foreach (var item in locacao.Itens)
            {
                locacao.Valor += item.Produto.Valor;

                if (numeroDeDiasEmAtraso > 0)
                {
                    if (item.Produto.TipoDeProduto == TipoDeProduto.Jogo) 
                    {
                        locacao.Multa += this.calculaMulta(numeroDeDiasEmAtraso, item.Produto.Valor, 100);
                    } 
                    else 
                    {
                        locacao.Multa += this.calculaMulta(numeroDeDiasEmAtraso, item.Produto.Valor, item.Produto.Midia.Multa);
                    }
                }
            }

            return _mapper.Map<LocacaoViewModel>(locacao);
        }

        private double calculaMulta(int numeroDePeriodos, double valorOriginal, double taxa)
        {
            return (((taxa / 100) * numeroDePeriodos) * valorOriginal);            
        }
    }
}

