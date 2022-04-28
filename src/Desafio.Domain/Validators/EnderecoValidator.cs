using Desafio.Domain.ValueObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.Street)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 50).WithMessage("O campo {PropertyName} deve ter entre 5 e 50 caracteres");
            RuleFor(e => e.City)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 25).WithMessage("O campo {PropertyName} deve ter entre 5 e 25 caracteres");
            RuleFor(e => e.State)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .MaximumLength(2).WithMessage("O campo {PropertyName} deve ter no máximo 2 caracteres");
            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 25).WithMessage("O campo {PropertyName} deve ter entre 5 e 25 caracteres");
            RuleFor(e => e.NeighborHood)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(10, 100).WithMessage("O campo {PropertyName} deve ter entre 10 e 100 caracteres");
            RuleFor(e => e.Service)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 15).WithMessage("O campo {PropertyName} deve ter entre 5 e 15 caracteres");

        }
    }
}
