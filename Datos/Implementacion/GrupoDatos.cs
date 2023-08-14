using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class GrupoDatos: IGenericDatos<Grupo>
    {
        private readonly string _cadenaSql = "";
        public GrupoDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<Grupo> GetList()
        {
            List<Grupo> lista = new List<Grupo>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarGrupo",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Grupo
                        {
                            IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
                            Nombre = dr["Nombre"].ToString(),
                            IdCC1 = new CuatriCarrera
                            {
                                IdCC = Convert.ToInt32(dr["IdCC"]),
                                IdCarrera1 = new Carrera 
                                {
                                    IdCarrera = Convert.ToInt32(dr["IdCarrera"]),
                                    Nombre = dr["Nombre"].ToString()
                                },
                                IdCuatrimestre1 = new Cuatrimestre
                                {
                                    IdCuatrimestre = Convert.ToInt32(dr["IdCuatrimestre"]),
                                    NroCuatrimestre = Convert.ToInt32(dr["NroCuatrimestre"])
                                }
                            }
                        });
                    }
                }
            }
            return lista;
        }
        public bool Guardar(Grupo model)
        {
            using(var conexion = new SqlConnection(_cadenaSql)){
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregarGrupo",conexion);
                cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                cmd.Parameters.AddWithValue("IdCC1",model.IdCC1.IdCC);
                cmd.CommandType = CommandType.StoredProcedure;
                int filaAfectada = cmd.ExecuteNonQuery();
                if(filaAfectada>0)
                {
                    return true;
                }
                else { 
                    return false; 
                }
            }
        }
        public bool Eliminar(int idGrupo)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarGrupo", conexion);
                cmd.Parameters.AddWithValue("IdGrupo", idGrupo);
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