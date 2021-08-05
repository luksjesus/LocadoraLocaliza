using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public DateTime DataLancamento { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "O valor deve ser maior que 0")]
        public Double Valor { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "O valor deve ser maior que 0")]
        public int Quantidade { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "O valor deve ser maior que 0")]
        public int QuantidadeDisponivel { get; set; }
        
        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public Guid MidiaId { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public int TipoDeProduto { get; set; }

        public Boolean Ativo { get; set; }
    }
}
