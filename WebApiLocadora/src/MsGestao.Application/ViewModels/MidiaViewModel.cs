using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.ViewModels
{
    public class MidiaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Descricao { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "Valor da multa deve ser maior que 0")]
        public Double Multa { get; set; }
        
        public Boolean Ativo { get; set; }
    }
}
