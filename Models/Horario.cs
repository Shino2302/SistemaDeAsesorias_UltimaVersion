namespace SistemaDeAsesorias.Models
{
    public class Horario
    {
        public int IdHorario {get;set;}
        public required HoraModel IdHora1 {get;set;}
        public required MinutosModel IdMinutos1 {get;set;}
        public required Dias IdDia1 {get;set;}
        public required Materia IdMateria1 {get;set;}
    }
}