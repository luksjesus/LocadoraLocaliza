using FluentValidation;
using Locadora.Domain.Models;

namespace Locadora.Domain.Validations
{
    public class MidiaValidation : AbstractValidator<Midia>
    {
        public MidiaValidation()
        {
            RuleFor(f => f.Descricao)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(f => f.Multa)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser maior ou igual a 0");
        }
    }
}
