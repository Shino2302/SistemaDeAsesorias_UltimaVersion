namespace SistemaDeAsesorias.Datos.Contrato
{
    public interface IGenericDatos <T> where T : class
    {
        List<T> GetList();
        bool Guardar(T Model);
        bool Eliminar(int id);
    }
}