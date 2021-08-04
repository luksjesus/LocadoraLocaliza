using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        // [StringLength(ErrorMessage = "O campo {0} deve ter entre {1} caracteres", MinimumLength = 3)]
        public string CPF { get; set; }
        
        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Cep { get; set; }
        
        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} deve ser preenchido")]
        public string Estado { get; set; }
        public string Complemento { get; set; }
      
       
        
        public Boolean Ativo { get; set; }
    }
}
