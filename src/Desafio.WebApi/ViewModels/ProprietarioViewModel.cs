using Desafio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Desafio.WebApi.ViewModels
{
    public class ProprietarioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo 50 caracteres")]
        [MinLength(10, ErrorMessage = "O campo {0 deve ter no mínimo 10 caracteres}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int Documento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O endereço fornecido não é válido!")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo 50 caracteres")]
        [MinLength(10, ErrorMessage = "O campo {0 deve ter no mínimo 10 caracteres}")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string NeighborHood { get; set; }
        public string Street { get; set; }
        public string Service { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public EStatus Status { get;  set; }

        public List<VeiculoViewModel> Veiculos { get; set;}
    }
}
