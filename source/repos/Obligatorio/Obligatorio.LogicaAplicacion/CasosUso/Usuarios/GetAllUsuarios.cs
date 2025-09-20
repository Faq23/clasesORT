using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetAllUsuarios : ICUGetAll<UsuarioDTOListado>
    {
        private IRepositorioUsuario _repo;

        public GetAllUsuarios(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public IEnumerable<UsuarioDTOListado> Execute()
        {
            return UsuarioMapper.ToListDTO(_repo.GetAll());
        }
    }
}
