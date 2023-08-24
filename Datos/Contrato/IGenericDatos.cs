namespace SistemaDeAsesorias.Datos.Contrato
{
    public interface IGenericDatos <T> where T : class
    {
        List<T> GetList();
        bool Guardar(T Model);
        bool Eliminar(int id);
    }
    public interface InterMultiDatos<T> where T : class
    {
        List<T> GetList();
        
    }
    public interface InMultiHorario<T> where T : class
    {
        List<T> GetList(int id);
    }
    public interface IGuardar<T> where T: class
    {
        bool Guardar(T Model, int id);
    }
}