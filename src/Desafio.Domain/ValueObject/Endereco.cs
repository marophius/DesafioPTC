using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.ValueObject
{
    public class Endereco
    {
        public Endereco(string cep, string state, string neighborHood, string street, string service)
        {
            Cep = cep;
            State = state;
            NeighborHood = neighborHood;
            Street = street;
            Service = service;
        }

        public string Cep { get;  set; }
        public string State { get; set; }
        public string City { get; set; }
        public string NeighborHood { get; set; }
        public string Street { get; set; }
        public string Service { get; set; }
    }
}
