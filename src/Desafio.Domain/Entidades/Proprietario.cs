using Desafio.Domain.Enums;
using Desafio.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entidades
{
    public class Proprietario : Entity
    {
        public Proprietario(Nome nome, int documento, string email, Endereco endereco, EStatus status)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            Endereco = endereco;
            _veiculos = new List<Veiculo>();
            Status = status;
        }
        protected Proprietario()
        {

        }

        public Nome Nome { get; private set; }
        public int Documento { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public EStatus Status { get; private set; }
        private readonly List<Veiculo> _veiculos;
        public IReadOnlyCollection<Veiculo> Veiculos => _veiculos;

        public void Alterar(Nome nome, int documento, string email, Endereco endereco)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            Endereco = endereco;
        }

        public void Ativar()
        {
            Status = EStatus.Ativo;
        }

        public void Cancelar()
        {
            Status = EStatus.Cancelado;
        }

    }
}
