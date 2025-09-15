namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioGetByID<T>
    {
        T GetByID(int ID);
    }
}
