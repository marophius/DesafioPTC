using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<Veiculo> BuscarPorRenavam(int renavam);
        Task AtualizarVeiculo(Guid id, Veiculo veiculo);
    }
}
