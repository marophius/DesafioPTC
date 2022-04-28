using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<Marca> BuscarPorNome(string nome);
        Task<Marca> AtivarStatus(Guid Id);
        Task<Marca> CancelarStatus(Guid Id);
        Task<List<Marca>> SomenteAtivos();
    }
}
