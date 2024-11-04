using Eval3ProgAvanzada.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Eval3ProgAvanzada.Database
{
    public class ApplicationDbContext: System.Data.Entity.DbContext
    {
        internal readonly object Tools;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<marca> Marcas { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<modelo> Modelos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<herramienta> herramientas { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<usuario> usuarios { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<movimiento> movimientos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<asignacion> asignacion { get; set; }
    }
}
