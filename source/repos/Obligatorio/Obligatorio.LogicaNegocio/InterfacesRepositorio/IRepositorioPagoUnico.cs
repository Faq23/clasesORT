using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPagoUnico :
        IRepositorioAdd<PagoUnico>,
        IRepositorioGetAll<PagoUnico>,
        IRepositorioGetByID<PagoUnico>
    {
    }
}
