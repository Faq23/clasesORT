using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {
        protected Administrador() : base() { }
        public Administrador(Nombre nombre, Apellido apellido, Contrasena contrasena, Email email, int idEquipo, Equipo equipo) : base(nombre, apellido, contrasena, email, idEquipo, equipo)
        {
        }
    }
}
