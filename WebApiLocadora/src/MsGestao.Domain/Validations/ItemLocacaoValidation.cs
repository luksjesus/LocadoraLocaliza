using FluentValidation;
using Locadora.Domain.Models;

namespace Locadora.Domain.Validations
{
    public class ItemLocacaoValidation : AbstractValidator<ItemLocacao>
    {
        public ItemLocacaoValidation()
        {
            RuleFor(f => f.ProdutoId)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(f => f.LocacaoId)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");
        }
    }
}
