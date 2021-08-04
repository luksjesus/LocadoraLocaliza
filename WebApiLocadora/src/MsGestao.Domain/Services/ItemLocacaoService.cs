using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Validations;
using Locadora.Domain.Notificador;
using System;

namespace Locadora.Domain.Services
{
    public class ItemLocacaoService : BaseService, IItemLocacaoService
    {
        private readonly IItemLocacaoRepository _ItemLocacaoRepository;
                
        public ItemLocacaoService(IItemLocacaoRepository ItemLocacaoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _ItemLocacaoRepository = ItemLocacaoRepository;
        }
        
        public bool Add(ItemLocacao itemLocacao)
        {
            if (!ExecutarValidacao(new ItemLocacaoValidation(), itemLocacao)) return false;

            _ItemLocacaoRepository.Add(itemLocacao);

            return true;
        }

        public bool Update(ItemLocacao itemLocacao)
        {
            if (!ExecutarValidacao(new ItemLocacaoValidation(), itemLocacao)) return false;

            _ItemLocacaoRepository.Update(itemLocacao);

            return true;
        }

        public void Delete(Guid id)
        {
            _ItemLocacaoRepository.Delete(id);
        }

        public void Dispose()
        {
            _ItemLocacaoRepository.Dispose();
        }     
    }
}
