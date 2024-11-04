using Eval3ProgAvanzada.Models;
using Microsoft.EntityFrameworkCore;

namespace Eval3ProgAvanzada.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<marca> Marcas { get; set; }
        public DbSet<modelo> Modelos { get; set; }
        public DbSet<Herramienta> herramientas { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<movimiento> movimientos { get; set; }
        public DbSet<asignacion> asignaciones { get; set; }
    }
}

