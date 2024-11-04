using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Eval3ProgAvanzada.Models
{
    public class herramienta
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("modelo")]
        public int modeloId { get; set; }
        public modelo modelo { get; set; }
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Estado { get; set; } // "Disponible", "En Uso", "En Mantención"

        [Required]
        public string NumeroSerie { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int CantidadTotal { get; set; }
        public int CantidadDisponible { get; set; }
        public int CantidadEnUso { get; set; }
        public int CantidadEnMantencion { get; set; }

    }
}
