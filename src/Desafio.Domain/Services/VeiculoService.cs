using Desafio.Domain.Entidades;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Notificacoes;
using Desafio.Domain.Validators;
using RabbitMQ.Client;
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
        private readonly IMarcaRepository _marcaRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public VeiculoService(
            INotificador notificador,
            IVeiculoRepository repository,
            IMarcaRepository marcaRepository,
            IProprietarioRepository proprietarioRepository) : base(notificador)
        {
            _repository = repository;
            _marcaRepository = marcaRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<bool> Adicionar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidator(), veiculo)) return false;

            var marcaValida = await VerificarMarca(veiculo.MarcaId);
            var proprietarioValido = await VerificarProprietario(veiculo.ProprietarioId);

            if (!marcaValida || !proprietarioValido) return false;

            if (_repository.Buscar(f => f.Renavam == veiculo.Renavam).Result.Any())
            {
                Notificar("Já existe um veiculo com este Renavam informado.");
                return false;
            }

            await _repository.Adicionar(veiculo);

            var veiculoQeue =  await _repository.BuscarPorRenavam(veiculo.Renavam);

            #region Qeue
            var factory = new ConnectionFactory()
            {
                HostName = "bunny",
                Port = 5672
            };
            using (var connection = factory.CreateConnection()) 
                using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "veiculoQeue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = System.Text.Json.JsonSerializer.Serialize(veiculoQeue);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "veiculoQeue",
                    basicProperties: null,
                    body: body);
            }
            #endregion

            
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

        public async Task<bool> VerificarMarca(Guid id)
        {
            if (id == Guid.Empty || id == null) return false;

            var marca = await _marcaRepository.BuscarPorId(id);

            if (marca == null || marca.Status == EStatus.Cancelado)
            {
                Notificar("Não é possível cadastrar um veículo sem uma marca ou com uma marca cancelada!");

                return false;
            }

            return true;
        }

        public async Task<bool> VerificarProprietario(Guid id)
        {
            if (id == Guid.Empty || id == null) return false;

            var proprietario = await _proprietarioRepository.BuscarPorId(id);

            if (proprietario == null || proprietario.Status == EStatus.Cancelado)
            {
                Notificar("Não é possível cadastrar um veículo sem um proprietário ou com um proprietário cancelado!");
                return false;
            }

            return true;
        }
    }
}
