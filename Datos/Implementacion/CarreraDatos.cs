using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Datos.Implementacion
{
    public class CarreraDatos : IGenericDatos<Carrera>
    {
        private readonly string _cadenaSql = "";
        public CarreraDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<Carrera> GetList()
        {
            List<Carrera> lista = new List<Carrera>();
            using (var conexion = new SqlConnection(_cadenaSql)){
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCarrera",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = cmd.ExecuteReader())
                {
                    while(dr.Read()){
                        
                        lista.Add(new Carrera
                        {
                            IdCarrera = Convert.ToInt32(dr["IdCarrera"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
                return lista;
            }
        }
        public bool Guardar(Carrera model)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregarCarrera", conexion);
                cmd.Parameters.AddWithValue("Nombre", model.Nombre);
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
        public bool Eliminar(int idCarrera)
        {
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarCarrera", conexion);
                cmd.Parameters.AddWithValue("IdCarrera", idCarrera);
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