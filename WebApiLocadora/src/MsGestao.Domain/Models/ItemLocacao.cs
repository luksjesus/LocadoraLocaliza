using System;

namespace Locadora.Domain.Models
{
    public class ItemLocacao : Entity
    {
        public Guid LocacaoId { get; set; }
        public Guid ProdutoId { get; set; }
        
        //---> Propriedades de navegação
        //
        public Locacao Locacao { get; set; }
        public Produto Produto { get; set; }
    }
}
