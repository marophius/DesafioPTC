using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.ValueObject
{
    public class Nome
    {
        public string Valor { get; set; }

        public Nome(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Valor = valor;
            }
        }
    }
}
