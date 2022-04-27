using Desafio.Data.Repositories;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public int Commit()
        {
           return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        // QUESTIONAR SOBRE UNIT OF WORK

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            var repository = new Repository<T>(_context);
            return repository;
        }
    }
}
