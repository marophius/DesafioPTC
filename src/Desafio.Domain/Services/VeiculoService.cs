using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Notificacoes;
using Desafio.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class VeiculoService : BaseService, IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(
            INotificador notificador,
            IVeiculoRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<bool> Adicionar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidator(), veiculo)
                || !ExecutarValidacao(new ProprietarioValidator(), veiculo.Proprietario)) return false;

            if (_repository.Buscar(f => f.Renavam == veiculo.Renavam).Result.Any())
            {
                Notificar("Já existe um veiculo com este Renavam informado.");
                return false;
            }

            await _repository.Adicionar(veiculo);
            return true;
        }

        public async Task<bool> Atualizar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidator(), veiculo)) return false;

            if (_repository.Buscar(f => f.Renavam == veiculo.Renavam && f.Id != veiculo.Id).Result.Any())
            {
                Notificar("Já existe um veiculo com este Renavam infomado.");
                return false;
            }

            await _repository.AtualizarVeiculo(veiculo.Id, veiculo);
            return true;
        }
    }
}
