using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Pago : IEntity, IValidable
    {
        public int ID { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public TipoGasto TipoGastoAsociado { get; set; }
        public Usuario Usuario { get; set; }
        public DescripcionPago DescripcionPago { get; set; }

        public Pago(int id, MetodoPago metodoPago, TipoGasto tipoGastoAsociado, Usuario usuario, DescripcionPago descripcionPago)
        {
            ID = id;
            MetodoPago = metodoPago;
            TipoGastoAsociado = tipoGastoAsociado;
            Usuario = usuario;
            DescripcionPago = descripcionPago;

            Validar();
        }

        public void Validar()
        {
            throw new PagoException();
        }
    }
}
