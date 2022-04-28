using Desafio.Domain.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Validators
{
    public class ProprietarioValidator : AbstractValidator<Proprietario>
    {
        public ProprietarioValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(10, 35).WithMessage("O campo {PropertyName} deve ter entre 10 e 35 caracteres")
                .EmailAddress();
            RuleFor(p => p.Documento)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que 0");
        }
    }
}
