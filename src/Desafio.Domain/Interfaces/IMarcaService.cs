using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IMarcaService
    {
        Task<bool> Adicionar(Marca marca);
        Task<bool> AtivarStatus(Guid id);
        Task<bool> CancelarStatus(Guid id);
    }
}
