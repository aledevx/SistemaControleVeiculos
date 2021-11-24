using System;

namespace SistemaControleVeiculos.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
        public Motorista Motorista { get; set; }
        public int MotoristaId { get; set; }
        public Setor Setor { get; set; }
        public int SetorId { get; set; }
        public string NumProcesso { get; set; }
        public string Observacao { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
    }
}