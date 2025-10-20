namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Pago
{
    public interface ICUPagoMensualList<T>
    {
        IEnumerable<T> Execute(int month, int year);
    }
}
