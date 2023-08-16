using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class GrupoMultiTabDatos : InterMultiDatos<ConsultaGrupoModel>
    {
        public readonly string _cadenaSql = "";
        public GrupoMultiTabDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<ConsultaGrupoModel> GetList()
        {
            List<ConsultaGrupoModel> lista = new List<ConsultaGrupoModel>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_InfoGrupo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ConsultaGrupoModel
                        {
                            IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
                            Grupo = dr["Grupo"].ToString(),
                            Cuatrimestre = Convert.ToInt32(dr["Cuatrimestre"]),
                            Carrera = dr["Carrera"].ToString()
                        });
                    }
                }
                return lista;
            }
        }
    }
}
