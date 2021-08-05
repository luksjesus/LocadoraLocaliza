﻿using FluentValidation;
using Locadora.Domain.Models;

namespace Locadora.Domain.Validations
{
    public class LocacaoValidation : AbstractValidator<Locacao>
    {
        public LocacaoValidation()
        {
            RuleFor(f => f.DataCadastro)
               .NotNull().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(f => f.Valor)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ser maior ou igual a 0");

            //RuleFor(f => f.StatusDaVenda)
            //   .NotNull(0).WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(f => f.Itens.Count)
               .GreaterThan(0).WithMessage("Os itens para locação devem ser selecionados");


        }
    }
}
