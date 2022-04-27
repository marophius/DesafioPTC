using Desafio.Domain.ValueObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Validators
{
    public class NomeValidator : AbstractValidator<Nome>
    {
        public NomeValidator()
        {
            RuleFor(n => n.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(5, 50).WithMessage("O campo {PropertyName} deve ter entre 5 e 50 caracteres!");
        }
    }
}
