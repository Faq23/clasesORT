using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class AddUsuario : ICUAdd<UsuarioDTOAlta>
    {
        private IRepositorioUsuario _repo;

        public AddUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(UsuarioDTOAlta obj)
        {
            _repo.Add(UsuarioMapper.FromDTO(obj));
        }
    }
}
