using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IValidable
    {
        public int ID { get; set; }
        public Nombre Nombre { get; set; }
        public Apellido Apellido { get; set; }
        public Contrasena Contrasena { get; set; }
        public Email Email { get; set; }

        public Usuario(int id, Nombre nombre, Apellido apellido, Contrasena contrasena, Email email)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
            Email = email;

            Validar();
        }

        public void Validar()
        {
            if (false)
            {
                throw new UsuarioException();
            }
        }
    }
}
