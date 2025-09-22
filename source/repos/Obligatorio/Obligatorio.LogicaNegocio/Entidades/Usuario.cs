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
        public int IDEquipo { get; set; } // FK Equipo
        public Equipo Equipo { get; set; }

        protected Usuario() { }

        public Usuario(Nombre nombre, Apellido apellido, Contrasena contrasena, Email email, int idEquipo, Equipo equipo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
            Email = email;
            IDEquipo = idEquipo;
            Equipo = equipo;

            Validar();
        }

        public void Validar() { }
    }
}
