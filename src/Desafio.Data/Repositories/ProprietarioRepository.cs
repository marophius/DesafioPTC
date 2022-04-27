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
    public class ProprietarioRepository : Repository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(DataContext context) : base(context)
        {
        }

        public async Task AtivarStatus(Guid id)
        {

            var proprietario = await BuscarPorId(id);

            if (proprietario == null) return;

            proprietario.Ativar();

            await Atualizar(proprietario);
        }

        public async Task AtualizarProprietario(Guid id, Proprietario proprietario)
        {
            var proprietarioAntigo = await BuscarPorId(id);

            if (proprietarioAntigo == null) return;

            proprietarioAntigo.Alterar(proprietario.Nome, proprietario.Documento, proprietario.Email, proprietario.Endereco);

            await Atualizar(proprietarioAntigo);

        }

        public async Task<Proprietario> BuscarPorDocumento(int documento)
        {
            var proprietario = await _context.Proprietarios.AsNoTracking().FirstOrDefaultAsync(x => x.Documento == documento);
            return proprietario;
        }

        public async Task CancelarStatus(Guid id)
        {
            var proprietario = await BuscarPorId(id);

            if(proprietario == null) return;

            proprietario.Cancelar();

            await Atualizar(proprietario);
        }

        public async Task<List<Proprietario>> SomenteAtivos()
        {
            return await _context.Proprietarios.Where(p => p.Status == EStatus.Ativo).AsNoTracking().ToListAsync();
        }
    }
}
