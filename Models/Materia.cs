
namespace SistemaDeAsesorias.Models
{
    public class Materia
    {
        public int IdMateria {get; set;}
        public required string Nombre {get;set;}
        public required CuatriCarrera IdCC1 {get;set;}
        public required Asesor NroEmpleado2 {get;set;}
    }
}