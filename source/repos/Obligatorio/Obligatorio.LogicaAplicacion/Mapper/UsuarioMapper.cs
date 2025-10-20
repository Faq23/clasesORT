using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Factories;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTOAlta usuarioDTO, Equipo equipo)
        {
            UsuarioFactory uf = new UsuarioFactory();
            Usuario newUser = uf.Crear(usuarioDTO.Tipo);

            newUser.Nombre = new Nombre(usuarioDTO.Nombre);
            newUser.Apellido = new Apellido(usuarioDTO.Apellido);
            newUser.Contrasena = new Contrasena(usuarioDTO.Contrasena);
            newUser.Email = new Email(usuarioDTO.Email);
            newUser.IDEquipo = usuarioDTO.IDEquipo;
            newUser.Equipo = equipo;

            return newUser;
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
                Equipo: EquipoMapper.ToDTO(usuario.Equipo),
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

        public static UsuarioDTOListadoConMonto ToDTO(Usuario usuario, int monto)
        {
            return new UsuarioDTOListadoConMonto(
                ID: usuario.ID,
                Nombre: usuario.Nombre.Value,
                Apellido: usuario.Apellido.Value,
                Contrasena: usuario.Contrasena.Value,
                Email: usuario.Email.Value,
                IDEquipo: usuario.IDEquipo,
                Equipo: EquipoMapper.ToDTO(usuario.Equipo),
                Tipo: usuario.GetType().Name,
                Monto: monto
                );
        }

        public static IEnumerable<UsuarioDTOListadoConMonto> ToListDTOFromAnother(IEnumerable<Pago> pagos)
        {
            List<UsuarioDTOListadoConMonto> aux = new List<UsuarioDTOListadoConMonto>();

            foreach (Pago item in pagos)
            {
                aux.Add(ToDTO(item.Usuario, item.MontoPago.Value));
            }

            return aux;
        }
    }
}
