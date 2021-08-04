using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Validations;
using Locadora.Domain.Notificador;
using System;

namespace Locadora.Domain.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _ProdutoRepository;
                
        public ProdutoService(IProdutoRepository ProdutoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _ProdutoRepository = ProdutoRepository;
        }
        
        public bool Add(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            _ProdutoRepository.Add(produto);

            return true;
        }

        public bool Update(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            _ProdutoRepository.Update(produto);

            return true;
        }

        public void Delete(Guid id)
        {
            _ProdutoRepository.Delete(id);
        }

        public void Dispose()
        {
            _ProdutoRepository.Dispose();
        }     
    }
}
