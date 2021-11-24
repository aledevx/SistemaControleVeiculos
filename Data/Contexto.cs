using Microsoft.EntityFrameworkCore;

namespace SistemaControleVeiculos.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
            
        }
    }
}