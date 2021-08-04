using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Validations;
using Locadora.Domain.Notificador;
using System;

namespace Locadora.Domain.Services
{
    public class LocacaoService : BaseService, ILocacaoService
    {
        private readonly ILocacaoRepository _LocacaoRepository;
                
        public LocacaoService(ILocacaoRepository LocacaoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _LocacaoRepository = LocacaoRepository;
        }
        
        public bool Add(Locacao locacao)
        {
            if (!ExecutarValidacao(new LocacaoValidation(), locacao)) return false;

            _LocacaoRepository.Add(locacao);

            return true;
        }

        public bool Update(Locacao locacao)
        {
            if (!ExecutarValidacao(new LocacaoValidation(), locacao)) return false;

            _LocacaoRepository.Update(locacao);

            return true;
        }

        public void Delete(Guid id)
        {
            _LocacaoRepository.Delete(id);
        }

        public void Dispose()
        {
            _LocacaoRepository.Dispose();
        }     
    }
}
