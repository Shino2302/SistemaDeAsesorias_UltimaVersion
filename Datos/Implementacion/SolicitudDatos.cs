using SistemaDeAsesorias.Models;
using System.Data;
using System.Data.SqlClient;
namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class SolicitudDatos
    {
        private readonly string _cadenaSql = "";
        public SolicitudDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public bool Solicitar(SoliAsesoria model)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_SolicitarAsesoria", conexion);
                cmd.Parameters.AddWithValue("Modalidad", model.Modalidad);
                cmd.Parameters.AddWithValue("IdTA", model.IdTA1);
                cmd.Parameters.AddWithValue("NroEmpleado", model.NroEmpleado3.Nombres);
                cmd.Parameters.AddWithValue("Matricula", model.Matricula1.Nombres);
                cmd.Parameters.AddWithValue("IdMateria", model.IdMateria.Nombre);
                cmd.CommandType = CommandType.StoredProcedure;
                int filasAfectadas = cmd.ExecuteNonQuery();
                if(filasAfectadas > 0)
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
