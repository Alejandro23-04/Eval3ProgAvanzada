namespace Eval3ProgAvanzada.Models
{
    public class asignacion
    {
        public int Id { get; set; }

        public int herramientaId { get; set; }
        public Herramienta Herramienta { get; set; }

        public int usuarioId { get; set; }
        public usuario Usuario { get; set; }

        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
