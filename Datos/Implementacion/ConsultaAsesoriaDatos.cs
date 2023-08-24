using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;
namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class ConsultaAsesoriaDatos : InterMultiDatos<ConsultaAsesoria>
    {
        private readonly string _cadenaSql = "";
        public ConsultaAsesoriaDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<ConsultaAsesoria> GetList()
        {
            List<ConsultaAsesoria> lista = new List<ConsultaAsesoria>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaAsesoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ConsultaAsesoria
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Participantes = Convert.ToInt32(dr["Participantes"]),
                            Tipo = dr["Tipo"].ToString(),
                            Modalidad = dr["Modalidad"].ToString(),
                            Asesor = dr["Asesor"].ToString(),
                            Materia = dr["Materia"].ToString(),
                            IdAlumno = Convert.ToInt32(dr["IdAlumno"]),
                            Alumno_s = dr["Añumno_s"].ToString(),
                            Grupo = dr["Grupo"].ToString(),
                            Dia = dr["Dia"].ToString(),
                            Hora = Convert.ToInt32(dr["Hora"])
                        });

                    }
                }
            }
            return lista;
        }
                
    }
}
