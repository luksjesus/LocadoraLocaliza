using FluentValidation;
using Locadora.Domain.Models;

namespace Locadora.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(f => f.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(f => f.DataLancamento)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(f => f.Valor)
               .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser maior ou igual a 0");

            RuleFor(f => f.Quantidade)
               .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser maior ou igual a 0");

            RuleFor(f => f.QuantidadeDisponivel)
               .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser maior ou igual a 0");

            RuleFor(f => f.MidiaId)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");
        }
    }
}
