using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IProprietarioService 
    {
        Task<bool> Adicionar(Proprietario proprietario);
        Task<bool> Atualizar(Proprietario proprietario);
    }
}
