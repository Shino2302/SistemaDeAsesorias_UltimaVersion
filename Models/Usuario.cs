using SistemaDeAsesorias.Controllers;

namespace SistemaDeAsesorias.Models
{
    public class Usuario
    {
        public int IdUsuario {get;set;}
        public required TipoUsuario IdTU1 {get;set;}
        public required Alumno Matricula2 {get;set;}
        public required Asesor NroEmpleado4 {get;set;}
        public required string Pass {get;set;}
        public required string Email{get;set;}
    }
}