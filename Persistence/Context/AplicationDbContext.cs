using backendpreguntas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backendpreguntas.Persistence.Context
{
    public class AplicationDbContext:DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options)
        {
            
        }
    }
}
