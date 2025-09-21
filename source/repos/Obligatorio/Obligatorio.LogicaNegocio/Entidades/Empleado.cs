using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Empleado : Usuario
    {
        public Empleado(int id, Nombre nombre, Apellido apellido, Contrasena contrasena, Email email) : base(id, nombre, apellido, contrasena, email)
        {
        }
    }
}
