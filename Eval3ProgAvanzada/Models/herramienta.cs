using System.ComponentModel.DataAnnotations;

namespace Eval3ProgAvanzada.Models
{
    public class herramienta
    {
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

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
