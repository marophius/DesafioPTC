using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        Task<Proprietario> BuscarPorDocumento(int documento);
        Task AtivarStatus(Guid id);
        Task CancelarStatus(Guid id);
        Task AtualizarProprietario(Guid id, Proprietario proprietario);
        Task<List<Proprietario>> SomenteAtivos();
    }
}
