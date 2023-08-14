namespace SistemaDeAsesorias.Models
{
    public class Asesoria
    {
        public int IdAsesoria {get;set;}
        public int Duracion {get;set;}
        public int Calificacion {get;set;}
        public int NroAlumnos {get;set;}
        public required SoliAsesoria IdSolicitud1 {get;set;}         
    }
}