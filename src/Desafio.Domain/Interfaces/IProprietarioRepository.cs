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
        Task<Proprietario> AtivarStatus(Guid id);
        Task<Proprietario> CancelarStatus(Guid id);
        Task<Proprietario> AtualizarProprietario(Guid id, Proprietario proprietario);
        Task<List<Proprietario>> SomenteAtivos();
    }
}
