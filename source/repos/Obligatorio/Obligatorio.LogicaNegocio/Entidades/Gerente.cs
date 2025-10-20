using Obligatorio.LogicaNegocio.vo.Usuario;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Gerente : Usuario
    {
        public Gerente() : base() { }

        public Gerente(Nombre nombre, Apellido apellido, Contrasena contrasena, Email email, int idEquipo, Equipo equipo) : base(nombre, apellido, contrasena, email, idEquipo, equipo)
        {
        }
    }
}
