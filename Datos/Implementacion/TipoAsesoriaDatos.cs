using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class TipoAsesoriaDatos : IGenericDatos<TipoAsesoria>
    {
        private readonly string _cadenaSql = "";
        public TipoAsesoriaDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<TipoAsesoria> GetList()
        {
            List<TipoAsesoria> lista = new List<TipoAsesoria>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTA", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new TipoAsesoria
                        {
                            IdTA = Convert.ToInt32(dr["IdTA"]),
                            Tipo = dr["Tipo"].ToString()
                        });
                    }
                }
                return lista;
            }
        }
        public bool Guardar(TipoAsesoria model)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregarTA", conexion);
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
        public bool Eliminar(int idTA)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarTA", conexion);
                cmd.Parameters.AddWithValue("IdTA", idTA);
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
