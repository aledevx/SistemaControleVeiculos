using System.Collections.Generic;

namespace SistemaControleVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status { get; set; }
        public ICollection<Viagem> Viagens { get; set; }
    }
}