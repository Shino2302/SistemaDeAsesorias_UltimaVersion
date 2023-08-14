namespace SistemaDeAsesorias.Models
{
    public class Asesor
    {
        public int NroEmpleado { get; set; }
        public required string Nombres { get; set; }
        public required string ApePat { get; set; }
        public required string ApeMat { get; set; }
        public required string CURP { get; set; }
        public required string RFC { get; set; }
        public required string Telefono { get; set; }
        public required string NivEstudios { get; set; }

    }
}