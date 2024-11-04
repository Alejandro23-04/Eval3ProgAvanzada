using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eval3ProgAvanzada.Models
{
    public class movimiento
    {
        public int Id { get; set; }


        [ForeignKey("Herramienta")] 
        public int herramientaId { get; set; }
        public herramienta Herramienta { get; set; }

        [ForeignKey("Usuario")]
        public int userId { get; set; }
        public usuario usuario { get; set; }

        [Required]
        public string TipoMovimiento { get; set; } // "Ingreso", "Asignación", "Mantención", "Reingreso"

        public DateTime FechaMovimiento { get; set; }
        public int ResponsableId { get; set; }
    }
}
