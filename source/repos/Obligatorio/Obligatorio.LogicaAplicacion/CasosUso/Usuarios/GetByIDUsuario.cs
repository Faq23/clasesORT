using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetByIDUsuario : ICUGetByID<UsuarioDTOListado>
    {
        private IRepositorioUsuario _repo;

        public GetByIDUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }
        public UsuarioDTOListado Execute(int id)
        {
            return UsuarioMapper.ToDTO(_repo.GetByID(id));
        }
    }
}