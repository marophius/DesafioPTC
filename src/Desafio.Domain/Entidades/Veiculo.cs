using Desafio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entidades
{
    public class Veiculo : Entity
    {
        public Veiculo(
            Guid proprietarioId,
            int renavam,
            Guid marcaId,
            string modelo,
            int anoFabricacao,
            int anoModelo,
            double quilometragem,
            double valor,
            EVeiculoStatus status
            )
        {
            ProprietarioId = proprietarioId;
            Renavam = renavam;
            MarcaId = marcaId;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Quilometragem = quilometragem;
            Valor = valor;
            Status = status;
        }

        protected Veiculo()
        {

        }
        public Guid ProprietarioId { get; private set; }
        public Proprietario Proprietario { get; private set; }
        public int Renavam { get; private set; }
        public Guid MarcaId { get; private set; }
        public Marca Marca { get; private set; }
        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }
        public int AnoModelo { get; private set; }
        public double Quilometragem { get; private set; }
        public double Valor { get; private set; }
        public EVeiculoStatus Status { get; private set; }

        public void StatusVendido()
        {
            Status = EVeiculoStatus.Vendido;
        }

        public void StatusIndisponivel()
        {
            Status = EVeiculoStatus.Indisponivel;
        }

        public void Alterar(Guid proprietarioId, int renavam, Guid marcaId, string modelo, int anoFabricacao, int anoModelo, double quilometragem, double valor)
        {
            ProprietarioId = proprietarioId;
            Renavam = renavam;
            MarcaId = marcaId;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Quilometragem = quilometragem;
            Valor = valor;
        }

    }
}
