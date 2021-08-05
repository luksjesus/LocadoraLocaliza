using System;

namespace Locadora.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public Double Valor { get; set; }

        public int Quantidade { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public Guid MidiaId { get; set; }
        public int TipoDeProduto { get; set; }
        

        //---> Propriedade de navegação
        //
        public Midia Midia { get; set; }
        
    }
}
