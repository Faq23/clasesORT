using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Gerente : Usuario
    {
        public Gerente(int id, Nombre nombre, Apellido apellido, Contrasena contrasena, Email email) : base(id, nombre, apellido, contrasena, email)
        {
        }
    }
}
