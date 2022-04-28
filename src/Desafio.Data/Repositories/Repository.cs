using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private IUnitOfWork _unitOfWork;
        protected readonly DataContext _context;
        private DbSet<T> _dbSet;
        private DataContext context;

        public Repository(
            DataContext context,
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _dbSet = context.Set<T>();
        }

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => (IUnitOfWork)_context;

        public async Task Adicionar(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            //await UnitOfWork.CommitAsync();
        } 

        public async Task Atualizar(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            //await UnitOfWork.CommitAsync();
        }

        public async Task<List<T>> Buscar()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> BuscarPorId(Guid id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public void Dispose()
        {
            _context.Dispose();
        }

        //public async Task Remover(Guid id)
        //{
        //    var entity = await BuscarPorId(id);
        //    _dbSet.Remove(entity);
        //}
    }
}
