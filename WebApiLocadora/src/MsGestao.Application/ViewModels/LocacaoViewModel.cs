﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.ViewModels
{
    public class LocacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public DateTime DataCadastro { get; set; }

        public DateTime DataLiberacao { get; set; }
        public DateTime DataEntrega { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "Valor total da locação deve ser maior que 0")]
        public Double ValorTotal { get; set; }

        [Range(0, 5, ErrorMessage = "O status da venda é invalido")]
        public int Status { get; set; }
        
        public Boolean Ativo { get; set; }

        public ICollection<ItemLocacaoViewModel> Itens { get; set; }
    }
}