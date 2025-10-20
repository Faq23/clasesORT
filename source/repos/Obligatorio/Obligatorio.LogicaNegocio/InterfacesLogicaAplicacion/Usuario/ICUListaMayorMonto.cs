namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Usuario
{
    public interface ICUListaMayorMonto<T>
    {
        IEnumerable<T> Execute(int monto);
    }
}
