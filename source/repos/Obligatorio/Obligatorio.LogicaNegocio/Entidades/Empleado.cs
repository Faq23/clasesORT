using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Empleado : Usuario
    {
        protected Empleado() : base() { }

        public Empleado(Nombre nombre, Apellido apellido, Contrasena contrasena, Email email, int idEquipo, Equipo equipo) : base(nombre, apellido, contrasena, email, idEquipo, equipo)
        {
        }
    }
}
