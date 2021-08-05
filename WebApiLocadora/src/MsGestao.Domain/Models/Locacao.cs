using System;
using System.Collections.Generic;

namespace Locadora.Domain.Models
{
    public class Locacao : Entity
    {
        public DateTime DataCadastro { get; set; }
        public DateTime DataLiberacao { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public DateTime DataEntrega { get; set; }
        public Double Valor { get; set; }
        public Double Multa { get; set; }
        public int Status { get; set; }
        public Guid ClienteId { get; set; }

        //---> Propriedade de navegação
        //
        public ICollection<ItemLocacao> Itens { get; set; }
        public Cliente Cliente { get; set; }
    }
}
