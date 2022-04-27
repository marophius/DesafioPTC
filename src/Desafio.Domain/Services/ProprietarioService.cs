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
    public class ProprietarioService : BaseService, IProprietarioService
    {
        private readonly IProprietarioRepository _repository;

        public ProprietarioService(
            INotificador notificador,
            IProprietarioRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<bool> Adicionar(Proprietario proprietario)
        {
            if (!ExecutarValidacao(new ProprietarioValidator(), proprietario)
                || !ExecutarValidacaoVO(new EnderecoValidator(), proprietario.Endereco)) return false;

            if (_repository.Buscar(f => f.Documento == proprietario.Documento).Result.Any())
            {
                Notificar("Já existe um proprietário com este documento informado.");
                return false;
            }

            await _repository.Adicionar(proprietario);
            return true;
        }

        public async Task<bool> Atualizar(Proprietario proprietario)
        {
            if (!ExecutarValidacao(new ProprietarioValidator(), proprietario)
                || !ExecutarValidacaoVO(new EnderecoValidator(), proprietario.Endereco)) return false;

            if (_repository.Buscar(f => f.Documento == proprietario.Documento && f.Id != proprietario.Id).Result.Any())
            {
                Notificar("Já existe um proprietario com este documento infomado.");
                return false;
            }

            await _repository.AtualizarProprietario(proprietario.Id, proprietario);
            return true;
        }
    }
}
