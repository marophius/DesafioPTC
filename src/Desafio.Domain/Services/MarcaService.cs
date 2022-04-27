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
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IMarcaRepository _repository;
        public MarcaService(
            INotificador notificador,
            IMarcaRepository repository
            ) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<bool> Adicionar(Marca marca)
        {
            if(!ExecutarValidacaoVO(new NomeValidator(), marca.Nome)) return false;

            if (_repository.Buscar(f => f.Nome.Valor == marca.Nome.Valor).Result.Any())
            {
                Notificar("Já existe uma marca com este nome informado.");
                return false;
            }

            await _repository.Adicionar(marca);
            return true;
        }

        public async Task<bool> AtivarStatus(Guid id)
        {
            if(id == Guid.Empty)
            {
                Notificar("O Id não pode ser vazio!");
                return false;
            }

            await _repository.AtivarStatus(id);
            return true;
        }

        public async Task<bool> CancelarStatus(Guid id)
        {
            if (id == Guid.Empty)
            {
                Notificar("O Id não pode ser vazio!");
                return false;
            }

            await _repository.CancelarStatus(id);
            return true;
        }

        //public async Task<bool> Remover(Guid id)
        //{
        //    if(id == Guid.Empty) return false;

        //    await _repository.Remover(id);

        //    return true;
        //}
    }
}
