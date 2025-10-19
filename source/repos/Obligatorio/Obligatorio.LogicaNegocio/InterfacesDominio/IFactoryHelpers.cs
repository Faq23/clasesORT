namespace Obligatorio.LogicaNegocio.InterfacesDominio
{
    internal static interface IFactoryHelpers<T>
    {
        T Crear(string tipo);
    }
}