namespace SistemaDeAsesorias.Models
{
    public class Alumno
    {
        public int Matricula {get;set;}
        public required string Nombres {get;set;}
        public required string ApePat {get;set;}
        public required string ApeMat {get;set;}
        public required string CURP {get;set;}
        public required string Telefono {get;set;}
        public required Grupo IdGrupo1 {get;set;}
    }
}