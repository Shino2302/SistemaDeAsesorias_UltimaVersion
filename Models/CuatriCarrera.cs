namespace SistemaDeAsesorias.Models
{
    public class CuatriCarrera
    {
        public int IdCC {get;set;}
        public required Carrera IdCarrera1 {get; set;}
        public required Cuatrimestre IdCuatrimestre1 {get;set;}       
    }
}