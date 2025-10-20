using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class AddUsuario : ICUAdd<UsuarioDTOAlta>
    {
        private IRepositorioUsuario _repo;
        private IRepositorioEquipo _repoEquipo;

        public AddUsuario(
            IRepositorioUsuario repo,
            IRepositorioEquipo repoEquipo)
        {
            _repo = repo;
            _repoEquipo = repoEquipo;
        }

        public void Execute(UsuarioDTOAlta obj)
        {
            _repo.Add(UsuarioMapper.FromDTO(
                obj,
                _repoEquipo.GetByID(obj.IDEquipo)
                ));
        }
    }
}
