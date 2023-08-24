using SistemaDeAsesorias.Datos;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data;
using System.Data.SqlClient;
namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class HorarioDatos : InMultiHorario<HorarioPorAsesor>
    {
        private readonly string _cadenaSql = "";
        public HorarioDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<HorarioPorAsesor> GetList(int NroEmpleado)
        {
            List<HorarioPorAsesor> lista = new List<HorarioPorAsesor>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarHorarioPorAse", conexion);
                cmd.Parameters.AddWithValue("@NroEmpleado", NroEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new HorarioPorAsesor
                        {
                            Hora = Convert.ToInt32(dr["Hora"]),
                            Minutos = Convert.ToInt32(dr["Minutos"]),
                            Dia = dr["Dia"].ToString(),
                            Materia = dr["Materia"].ToString(),
                            Nombres = dr["Nombres"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
       
        
    }
}
