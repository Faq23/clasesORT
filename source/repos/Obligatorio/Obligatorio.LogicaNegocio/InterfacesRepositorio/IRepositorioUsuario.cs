using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario :
        IRepositorioAdd<Usuario>,
        IRepositorioGetAll<Usuario>,
        IRepositorioGetByID<Usuario>,
        IRepositorioDelete<Usuario>
    {
    }
}
