using Desafio.Domain.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Validators
{
    public class MarcaValidator : AbstractValidator<Marca>
    {
        public MarcaValidator()
        {
            RuleFor(m => m.Id)
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} não pode ser vazio!");
        }
    }
}
