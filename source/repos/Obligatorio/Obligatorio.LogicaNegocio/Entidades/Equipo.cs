using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo.Equipo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Equipo : IEntity, IValidable
    {
        public int ID { get; set; }
        public NombreEquipo Nombre { get; set; }

        public IList<Usuario> Usuarios { get; set; } = new List<Usuario>();

        protected Equipo() { }
        public Equipo(NombreEquipo nombre)
        {
            Nombre = nombre;

            Validar();
        }

        public void Validar() { }
    }
}
