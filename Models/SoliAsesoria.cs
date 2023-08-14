namespace SistemaDeAsesorias.Models
{
    public class SoliAsesoria
    {
        public int IdSolicitud {get;set;}
        public DateTime FechaSolicitud {get;set;}
        public required string Modalidad {get;set;}
        public required TipoAsesoria IdTA1 {get;set;}
        public required Asesor NroEmpleado3 {get;set;}
        public required Alumno Matricula1 {get;set;}
        public required Materia IdMateria {get;set;}       
    }
}