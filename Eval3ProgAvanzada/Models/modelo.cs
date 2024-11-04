using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Eval3ProgAvanzada.Models
{
    public class modelo
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [ForeignKey("marca")]
        public int marcaId { get; set; }
        public marca marca { get; set; }
    }
}
