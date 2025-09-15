using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEquipo :
        IRepositorioAdd<Equipo>,
        IRepositorioGetAll<Equipo>,
        IRepositorioGetByID<Equipo>
    {
    }
}
