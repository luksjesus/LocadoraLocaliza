using FluentValidation;
using Locadora.Domain.Models;

namespace Locadora.Domain.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.CPF)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(11)
                .WithMessage("O campo {PropertyName} deve ter {MinLength}");

            RuleFor(f => f.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(8)
                .WithMessage("O campo {PropertyName} deve ter {MinLength}");

            RuleFor(f => f.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Numero)
                .NotNull().WithMessage("O campo {PropertyName} deve ser preenchido")
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que zero");

            RuleFor(f => f.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(2)
                .WithMessage("O campo {PropertyName} deve ter {MinLength} caracteres");

        }
    }
}
