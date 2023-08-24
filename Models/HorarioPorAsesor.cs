using System.ComponentModel.DataAnnotations;

namespace SistemaDeAsesorias.Models
{
    public class HorarioPorAsesor
    {
        public int Hora { get; set; }
        public int Minutos { get; set; }
        [Required]
        public string Dia { get; set; }
        [Required]
        public string Materia { get; set; }
        [Required]
        public string Nombres { get; set; }
    }
}
