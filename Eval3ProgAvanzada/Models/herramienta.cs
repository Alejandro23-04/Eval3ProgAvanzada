using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eval3ProgAvanzada.Models
{
    public class Herramienta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El modelo es requerido")]
        [ForeignKey("Modelo")]
        public int ModeloId { get; set; }

        public Modelo? Modelo { get; set; }  // Inicialización para evitar valores NULL

        [Required(ErrorMessage = "La marca es requerida")]
        [StringLength(50, ErrorMessage = "La marca no debe superar los 50 caracteres")]
        public string Marca { get; set; } = string.Empty;  // Cambiar a string para la marca

        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("Disponible|En Uso|En Mantención", ErrorMessage = "Estado no válido")]
        public string? Estado { get; set; } = "Disponible";  // Estado predeterminado

        [Required(ErrorMessage = "El número de serie es requerido")]
        [StringLength(100, ErrorMessage = "El número de serie no debe superar los 100 caracteres")]
        public string NumeroSerie { get; set; } = string.Empty;  // Valor predeterminado como cadena vacía

        [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe ser mayor a cero")]
        public int CantidadTotal { get; set; } = 1;  // Valor predeterminado para evitar error
    }

    public class Modelo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del modelo es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;  // Valor predeterminado como cadena vacía
    }
}
