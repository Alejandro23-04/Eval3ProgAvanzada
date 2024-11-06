using Eval3ProgAvanzada.Models;
using Microsoft.EntityFrameworkCore;

namespace Eval3ProgAvanzada.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<marca> Marcas { get; set; }
        public DbSet<modelo> Modelos { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<usuario> Usuarios { get; set; }
        public DbSet<movimiento> Movimientos { get; set; }
        public DbSet<asignacion> Asignaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
