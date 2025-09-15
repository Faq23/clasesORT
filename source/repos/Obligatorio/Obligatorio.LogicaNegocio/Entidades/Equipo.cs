using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Equipo : IEntity, IValidable
    {
        public int ID { get; set; }
        public Nombre Nombre { get; set; }

        public Equipo(int id, Nombre nombre)
        {
            ID = id;
            Nombre = nombre;
            Validar();
        }

        public void Validar() { }
    }
}
