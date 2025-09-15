namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUpdate<T>
    {
        void Update(int ID, T obj);
    }
}
