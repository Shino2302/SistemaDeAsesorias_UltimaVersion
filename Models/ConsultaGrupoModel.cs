using System.ComponentModel.DataAnnotations;

namespace SistemaDeAsesorias.Models
{
    //Class for make a query in more of one table on my database

    public class ConsultaGrupoModel
    {
        [Key]
        public int IdGrupo { get; set; }
        [Required]
        public string Grupo { get; set; }
        public int Cuatrimestre { get; set;}
        [Required]
        public string Carrera { get; set; }
    }
}
