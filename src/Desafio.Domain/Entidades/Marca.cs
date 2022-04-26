using Desafio.Domain.Enums;
using Desafio.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entidades
{
    public class Marca : Entity
    {
        public Nome Nome { get; private set; }
        public EStatus Status { get; set; }

        public Marca(Nome nome)
        {
            Nome = nome;
        }

        protected Marca()
        {

        }

        public void AlterarNome(string nome)
        {
            if(string.IsNullOrEmpty(nome))
            {
                Nome.Valor = nome;
            }
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
