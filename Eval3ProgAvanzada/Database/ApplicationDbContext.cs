using Eval3ProgAvanzada.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Eval3ProgAvanzada.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<herramienta> herramientas { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<movimiento> movimientos { get; set; }
        public DbSet<asignacion> asignacion { get; set; }
    }
}
