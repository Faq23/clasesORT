namespace Obligatorio.LogicaNegocio.InterfacesDominio
{
    public interface IFactory<T>
    {
        T Crear(string tipo);
    }
}
