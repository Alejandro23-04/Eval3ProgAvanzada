using System.ComponentModel.DataAnnotations;

namespace Eval3ProgAvanzada.Models
{
    public class movimiento
    {
        public int Id { get; set; }

        public int herramientaId { get; set; }
        public herramienta Herramienta { get; set; }

        public int UserId { get; set; }
        public usuario Usuario { get; set; }

        [Required]
        public string TipoMovimiento { get; set; } // "Ingreso", "Asignación", "Mantención", "Reingreso"

        public DateTime FechaMovimiento { get; set; }
        public int ResponsableId { get; set; }
    }
}
