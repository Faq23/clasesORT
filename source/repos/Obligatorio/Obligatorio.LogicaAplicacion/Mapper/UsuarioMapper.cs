using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTOAlta usuarioDTO)
        {
            switch (usuarioDTO.Tipo)
            {
                case "Administrador":
                    return new Administrador(
                        new Nombre(usuarioDTO.Nombre),
                        new Apellido(usuarioDTO.Apellido),
                        new Contrasena(usuarioDTO.Contrasena),
                        new Email(usuarioDTO.Email),
                        usuarioDTO.IDEquipo,
                        usuarioDTO.Equipo);

                case "Gerente":
                    return new Gerente(
                        new Nombre(usuarioDTO.Nombre),
                        new Apellido(usuarioDTO.Apellido),
                        new Contrasena(usuarioDTO.Contrasena),
                        new Email(usuarioDTO.Email),
                        usuarioDTO.IDEquipo,
                        usuarioDTO.Equipo);

                case "Empleado":
                    return new Empleado(
                        new Nombre(usuarioDTO.Nombre),
                        new Apellido(usuarioDTO.Apellido),
                        new Contrasena(usuarioDTO.Contrasena),
                        new Email(usuarioDTO.Email),
                        usuarioDTO.IDEquipo,
                        usuarioDTO.Equipo);

                default:
                    return new Usuario(
                        new Nombre(usuarioDTO.Nombre),
                        new Apellido(usuarioDTO.Apellido),
                        new Contrasena(usuarioDTO.Contrasena),
                        new Email(usuarioDTO.Email),
                        usuarioDTO.IDEquipo,
                        usuarioDTO.Equipo);
            }
        }

        public static UsuarioDTOListado ToDTO(Usuario usuario)
        {
            return new UsuarioDTOListado(
                ID: usuario.ID,
                Nombre: usuario.Nombre.Value,
                Apellido: usuario.Apellido.Value,
                Contrasena: usuario.Contrasena.Value,
                Email: usuario.Email.Value,
                IDEquipo: usuario.IDEquipo,
                Equipo: usuario.Equipo,
                Tipo: usuario.GetType().Name
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
