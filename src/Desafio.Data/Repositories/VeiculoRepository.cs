using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(DataContext context) : base(context)
        {
        }

        public async Task AtualizarVeiculo(Guid id, Veiculo veiculo)
        {
            var veiculoAntigo = await BuscarPorId(id);

            if (veiculoAntigo == null) return;

            veiculoAntigo.Alterar(veiculo.ProprietarioId, veiculo.Renavam, veiculo.MarcaId, veiculo.Modelo, veiculo.AnoFabricacao, veiculo.AnoModelo, veiculo.Quilometragem, veiculo.Valor);
           
            await Atualizar(veiculoAntigo);
        }

        public async Task<Veiculo> BuscarPorRenavam(int renavam)
        {
            var veiculo = await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(x => x.Renavam == renavam);

            return veiculo;
        }
    }
}
