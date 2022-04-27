using Desafio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Desafio.WebApi.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid ProprietarioId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int Renavam { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid MarcaId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(20, ErrorMessage = "o campo {0} deve ter entre {2} e {1} caracteres!", MinimumLength = 5)]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int AnoFabricacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int AnoModelo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Quilometragem { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public EVeiculoStatus Status { get; set; }
    }
}
