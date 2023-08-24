using SistemaDeAsesorias.Datos;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data;
using System.Data.SqlClient;
namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class HDat : IGuardar<Horario>
    {
        private readonly string _cadenaSql = "";
        public HDat(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public bool Guardar(Horario model, int NroEmpleado)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarHorarioAsesor", conexion);
                cmd.Parameters.AddWithValue("@NroEmpleado", NroEmpleado);
                cmd.Parameters.AddWithValue("IdHora", model.IdHora1);
                cmd.Parameters.AddWithValue("IdMinutos", model.IdMinutos1);
                cmd.Parameters.AddWithValue("IdDia", model.IdDia1);
                cmd.Parameters.AddWithValue("IdMateria", model.IdMateria1);
                cmd.CommandType = CommandType.StoredProcedure;
                int filaAfectada = cmd.ExecuteNonQuery();
                if (filaAfectada > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
