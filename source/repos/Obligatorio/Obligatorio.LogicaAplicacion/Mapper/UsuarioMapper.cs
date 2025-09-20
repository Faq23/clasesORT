using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTOAlta usuarioDTO)
        {
            return new Usuario(
                usuarioDTO.ID,
                new Nombre(usuarioDTO.Nombre),
                new Apellido(usuarioDTO.Apellido),
                new Contrasena(usuarioDTO.Contrasena),
                new Email(usuarioDTO.Email)
                );
        }

        public static UsuarioDTOListado ToDTO(Usuario usuario)
        {
            return new UsuarioDTOListado(
                ID: usuario.ID,
                Nombre: usuario.Nombre.Value,
                Apellido: usuario.Apellido.Value,
                Contrasena: usuario.Contrasena.Value,
                Email: usuario.Email.Value
                );
        }

        public static IEnumerable<UsuarioDTOListado> ToListDTO(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioDTOListado> aux = new List<UsuarioDTOListado>();

            foreach (Usuario item in usuarios)
            {
                aux.Add(ToDTO(item));
            }

            return aux;
        }
    }
}
