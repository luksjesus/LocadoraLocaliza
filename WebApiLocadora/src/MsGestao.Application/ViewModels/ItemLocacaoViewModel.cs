using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.ViewModels
{
    public class ItemLocacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid LocacaoId { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public Guid ProdutoId { get; set; }
       
        public Boolean Ativo { get; set; }
    }
}
