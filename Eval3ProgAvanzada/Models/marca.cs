
using System.ComponentModel.DataAnnotations;

namespace Eval3ProgAvanzada.Models
{
    public class marca
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
