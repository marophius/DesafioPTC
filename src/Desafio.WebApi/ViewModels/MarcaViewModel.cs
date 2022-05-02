using Desafio.Domain.Enums;
using Desafio.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace Desafio.WebApi.ViewModels
{
    public class MarcaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Nome Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public EStatus Status { get; set; }
        public IEnumerable<VeiculoViewModel> Veiculos { get; set; }
    }
}
