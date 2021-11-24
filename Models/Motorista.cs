using System.ComponentModel.DataAnnotations;

namespace SistemaControleVeiculos.Models
{
    public class Motorista
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "o Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }
    }
}