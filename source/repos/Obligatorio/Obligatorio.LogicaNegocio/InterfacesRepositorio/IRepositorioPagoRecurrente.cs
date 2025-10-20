using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPagoRecurrente :
        IRepositorioAdd<PagoRecurrente>,
        IRepositorioGetAll<PagoRecurrente>,
        IRepositorioGetByID<PagoRecurrente>
    {
    }
}
