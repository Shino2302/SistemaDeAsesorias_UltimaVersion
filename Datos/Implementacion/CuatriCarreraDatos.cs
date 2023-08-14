using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class CuatriCarreraDatos : IGenericDatos<CuatriCarrera>
    {
        private readonly string _cadenaSql = "";
        public CuatriCarreraDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<CuatriCarrera> GetList()
        {
            List<CuatriCarrera> lista = new List<CuatriCarrera>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new CuatriCarrera
                        {
                            IdCC = Convert.ToInt32(dr["IdCC"]),
                            IdCarrera1 = new Carrera{
                                IdCarrera = Convert.ToInt32(dr["IdCarrera"]),
                                Nombre = dr["Nombre"].ToString()
                            },
                            IdCuatrimestre1 = new Cuatrimestre{
                                IdCuatrimestre = Convert.ToInt32(dr["IdCuatrimestre"]),
                                NroCuatrimestre = Convert.ToInt32(dr["NroCuatrimestre"])
                            }
                        });
                    }
                }
            }
            return lista;
        }
        public bool Guardar(CuatriCarrera model)
        {
            throw new NotImplementedException();    
        }
        public bool Eliminar(int idCC)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarCC", conexion);
                cmd.Parameters.AddWithValue("IdCC", idCC);
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