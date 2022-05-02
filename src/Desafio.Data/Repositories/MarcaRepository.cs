using Desafio.Domain.Entidades;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Repositories
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(
            DataContext context,
            IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        

        public async Task<Marca> AtivarStatus(Guid id)
        {
            var marca = await BuscarPorId(id);

            if(marca == null) return null;

            marca.Ativar();

            await Atualizar(marca);
            return marca;
        }

        public async Task<List<Marca>> BuscarMarcasVeiculos()
        {
            var marcas = await _context.Marcas.AsNoTracking().Include(x => x.Veiculos).ToListAsync();

            return marcas;
        }

        public async Task<Marca> BuscarPorNome(string nome)
        {
            var marca = await _context.Marcas.AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Nome.Valor == nome);
            return marca;
        }

        public async Task<Marca> CancelarStatus(Guid Id)
        {
            var marca = await BuscarPorId(Id);
            if(marca == null) return null;
            marca.Cancelar();

            await Atualizar(marca);
            return marca;
        }

        public async Task<List<Marca>> SomenteAtivos()
        {
            return await _context.Marcas.Where(m => m.Status == EStatus.Ativo).AsNoTracking().ToListAsync();
        }
    }
}
