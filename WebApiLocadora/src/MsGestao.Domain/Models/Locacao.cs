using System;
using System.Collections.Generic;

namespace Locadora.Domain.Models
{
    public class Locacao : Entity
    {
        public DateTime DataCadastro { get; set; }
        public DateTime DataLiberacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public Double ValorTotal { get; set; }
        public int Status { get; set; }

        //---> Propriedade de navegação
        //
        public ICollection<ItemLocacao> Itens { get; set; }
    }
}
