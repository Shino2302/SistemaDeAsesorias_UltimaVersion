using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class TipoUsuarioDatos : IGenericDatos<TipoUsuario>
    {
        private readonly string _cadenaSql = "";
        public TipoUsuarioDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<TipoUsuario> GetList()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTU", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoUsuario
                        {
                            IdTU = Convert.ToInt32(dr["IdTU"]),
                            Tipo = dr["Tipo"].ToString()
                        });
                    }
                }
                return lista;
            }
        }
        public bool Guardar(TipoUsuario model)
        {
            using(var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregarTU", conexion);
                cmd.Parameters.AddWithValue("Tipo", model.Tipo);
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
        public bool Eliminar(int idTU)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarTU", conexion);
                cmd.Parameters.AddWithValue("IdTU", idTU);
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
