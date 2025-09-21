using Obligatorio.LogicaNegocio.Excepciones.TipoGasto;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class TipoGasto : IEntity, IValidable
    {
        public int ID { get; set; }
        public NombreGasto NombreGasto { get; set; }
        public Descripcion Descripcion { get; set; }

        public TipoGasto(int id, NombreGasto nombreGasto, Descripcion descripcion)
        {
            ID = id;
            NombreGasto = nombreGasto;
            Descripcion = descripcion;

            Validar();
        }

        public void Validar()
        {
            throw new TipoGastoException();
        }
    }
}
