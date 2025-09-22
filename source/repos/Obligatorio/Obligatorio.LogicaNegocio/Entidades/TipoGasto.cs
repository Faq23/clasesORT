using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class TipoGasto : IEntity, IValidable
    {
        public int ID { get; set; }
        public NombreGasto NombreGasto { get; set; }
        public Descripcion Descripcion { get; set; }

        protected TipoGasto() { }

        public TipoGasto(NombreGasto nombreGasto, Descripcion descripcion)
        {
            NombreGasto = nombreGasto;
            Descripcion = descripcion;

            Validar();
        }

        public void Validar() { }
    }
}
