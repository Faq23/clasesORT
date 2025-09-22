using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioTipoGasto :
        IRepositorioAdd<TipoGasto>,
        IRepositorioDelete<TipoGasto>,
        IRepositorioUpdate<TipoGasto>,
        IRepositorioGetAll<TipoGasto>,
        IRepositorioGetByID<TipoGasto>
    {
    }
}
