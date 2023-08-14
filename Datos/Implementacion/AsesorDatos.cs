using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class AsesorDatos : IGenericDatos<Asesor>
    {
        private readonly string _cadenaSql = "";
        public AsesorDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<Asesor> GetList()
        {
            List<Asesor> lista = new List<Asesor>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAsesor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        lista.Add(new Asesor
                        {
                            NroEmpleado = Convert.ToInt32(dr["NroEmpleado"]),
                            Nombres = dr["Nombres"].ToString(),
                            ApePat = dr["ApePat"].ToString(),
                            ApeMat = dr["ApeMat"].ToString(),
                            CURP = dr["CURP"].ToString(),
                            RFC = dr["RFC"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            NivEstudios = dr["NivEstudios"].ToString()
                        });
                    }
                }
                return lista;
            }
        }
        public bool Guardar(Asesor model)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregarAsesor", conexion);
                cmd.Parameters.AddWithValue("Nombres", model.Nombres);
                cmd.Parameters.AddWithValue("ApePat", model.ApePat);
                cmd.Parameters.AddWithValue("ApeMat", model.ApeMat);
                cmd.Parameters.AddWithValue("CURP", model.CURP);
                cmd.Parameters.AddWithValue("RFC", model.RFC);
                cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                cmd.Parameters.AddWithValue("NivEstudios", model.NivEstudios);
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
        public bool Eliminar(int nroEmpleado)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarAsesor", conexion);
                cmd.Parameters.AddWithValue("NroEmpleado", nroEmpleado);
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
