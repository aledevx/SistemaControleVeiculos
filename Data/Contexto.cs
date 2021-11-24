using Microsoft.EntityFrameworkCore;
using SistemaControleVeiculos.Models;

namespace SistemaControleVeiculos.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
    }
}