namespace SistemaDeAsesorias.Models
{
    public class Grupo
    {
        public int IdGrupo {get; set;}
        public required string Nombre {get;set;}
        public required CuatriCarrera IdCC1 {get;set;} 
    }
}