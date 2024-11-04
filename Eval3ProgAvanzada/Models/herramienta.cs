using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Eval3ProgAvanzada.Models
{
    public class Herramienta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El modelo es requerido")]
        [ForeignKey("Modelo")]
        public int ModeloId { get; set; }

        public Modelo Modelo { get; set; }  // Propiedad de navegación para Modelo

        [Required(ErrorMessage = "La marca es requerida")]
        [StringLength(50, ErrorMessage = "La marca no debe superar los 50 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("Disponible|En Uso|En Mantención", ErrorMessage = "Estado no válido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El número de serie es requerido")]
        [StringLength(100, ErrorMessage = "El número de serie no debe superar los 100 caracteres")]
        public string NumeroSerie { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe ser mayor a cero")]
        public int CantidadTotal { get; set; }
    }
    public class Modelo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del modelo es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; } // Puedes agregar otras propiedades según sea necesario
    }
}


