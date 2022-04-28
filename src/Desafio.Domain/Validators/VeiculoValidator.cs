using Desafio.Domain.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(v => v.MarcaId)
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} não pode ser vazio!");
            RuleFor(v => v.ProprietarioId)
                .NotEqual(Guid.Empty).WithMessage("O campo {PropertyName} não pode ser vazio!");
            RuleFor(v => v.Renavam)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que 0!");
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 15).WithMessage("O campo {PropertyName} deve ter entre 5 e 15 caracteres");
            RuleFor(v => v.Quilometragem)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!");
            RuleFor(v => v.AnoFabricacao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .LessThan(DateTime.Now.Year).WithMessage("O campo {PropertyName} não pode receber um valor maior que o ano atual");
            RuleFor(v => v.AnoModelo)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!");
            RuleFor(v => v.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio!")
                .GreaterThan(1000).WithMessage("O campo {PropertyName} precisa ter um valor acima de 1000");

        }
    }
}
