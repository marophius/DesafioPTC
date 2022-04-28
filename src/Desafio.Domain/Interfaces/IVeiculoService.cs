using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IVeiculoService
    {
        Task<bool> Adicionar(Veiculo veiculo);
        Task<bool> Atualizar(Veiculo veiculo);
        Task<bool> VerificarProprietario(Guid id);
        Task<bool> VerificarMarca(Guid id);
    }
}
