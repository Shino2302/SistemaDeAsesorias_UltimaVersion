using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class AlumnoDatos : IGenericDatos<Alumno>
    {
        private readonly string _cadenaSql ="";
        public AlumnoDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<Alumno> GetList()
        {
            List<Alumno> lista = new List<Alumno>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAlumno",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Alumno
                        {
                            Matricula = Convert.ToInt32(dr["Matricula"]),
                            Nombres = dr["Nombres"].ToString(),
                            ApePat = dr["ApePat"].ToString(),
                            ApeMat = dr["ApeMat"].ToString(),
                            CURP = dr["CURP"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            IdGrupo1 = new Grupo{
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
                                },


                            }
                        });
                    }
                }
                return lista;
            }
        }
        public bool Guardar(Alumno model)
            {
                using (var conexion = new SqlConnection(_cadenaSql))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregarAlumno",conexion);
                    cmd.Parameters.AddWithValue("Nombres",model.Nombres);
                    cmd.Parameters.AddWithValue("ApePat",model.ApePat);
                    cmd.Parameters.AddWithValue("ApeMat",model.ApeMat);
                    cmd.Parameters.AddWithValue("CURP",model.CURP);
                    cmd.Parameters.AddWithValue("Telefono",model.Telefono);
                    cmd.Parameters.AddWithValue("IdGrupo",model.IdGrupo1.IdGrupo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int filaAfectada = cmd.ExecuteNonQuery();
                    if(filaAfectada > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        public bool Eliminar(int matricula)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarAlumno", conexion);
                cmd.Parameters.AddWithValue("Matricula", matricula);
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