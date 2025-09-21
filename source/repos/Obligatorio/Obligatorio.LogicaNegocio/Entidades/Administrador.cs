using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {
        public Administrador(int id, Nombre nombre, Apellido apellido, Contrasena contrasena, Email email) : base(id, nombre, apellido, contrasena, email)
        {
        }
    }
}
