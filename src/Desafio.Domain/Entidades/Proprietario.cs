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
        public Nome Nome { get; private set; }
        public int Documento { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public EStatus Status { get; private set; }

    }
}
