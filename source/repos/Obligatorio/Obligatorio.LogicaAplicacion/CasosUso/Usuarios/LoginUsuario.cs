using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class LoginUsuario
    {
        IRepositorioUsuario _repo;

        public LoginUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioDTOListado Login(string emailUsuario, string contrasenaUsuario)
        {
            IEnumerable<UsuarioDTOListado> usuarios = UsuarioMapper.ToListDTO(_repo.GetAll());

            UsuarioDTOListado? usuario = usuarios.SingleOrDefault(u => u.Email == emailUsuario);

            if (usuario is null)
            {
                throw new LoginException();
            }

            if (usuario.Contrasena != contrasenaUsuario)
            {
                throw new LoginException();
            }

            return usuario;
        }
    }
}
