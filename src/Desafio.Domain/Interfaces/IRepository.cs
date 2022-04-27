using Desafio.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        #region CRUD

        Task Adicionar(T entity);
        Task<T> BuscarPorId(Guid id);
        Task<List<T>> Buscar();
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task Atualizar(T entity);
        //Task Remover(Guid id);

        #endregion
    }
}
