namespace SistemaDeAsesorias.Models
{
    public class ConsultaAsesoria
    {
        public int ID { get; set; }
        public int Participantes { get; set; }
        public string Tipo { get; set; }
        public string Modalidad { get; set; }
        public string Asesor { get; set; }
        public string Materia { get; set; }
        public int IdAlumno { get; set; }
        public string Alumno_s { get; set; }
        public string Grupo { get; set; }
        public string Dia { get; set; }
        public int Hora { get; set; }
    }
}
