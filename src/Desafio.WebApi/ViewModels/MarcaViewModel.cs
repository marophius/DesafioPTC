using Desafio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Desafio.WebApi.ViewModels
{
    public class MarcaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public EStatus Status { get; set; }
        public List<VeiculoViewModel> Veiculos { get; set; }
    }
}
