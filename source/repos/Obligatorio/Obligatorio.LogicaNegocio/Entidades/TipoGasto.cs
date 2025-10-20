using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo.TipoGasto;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class TipoGasto : IEntity, IValidable
    {
        public int ID { get; set; }
        public NombreGasto NombreGasto { get; set; }
        public Descripcion Descripcion { get; set; }

        // Relaciones

        public IList<Pago> Pagos { get; set; }

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
