namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUGetByID<T>
    {
        T Execute(int ID);
    }
}
