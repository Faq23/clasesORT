using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Pago : IEntity, IValidable
    {
        public int ID { get; set; }
        public DescripcionPago DescripcionPago { get; set; }

        // Relaciones

        public int IDUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public MetodoPago MetodoPago { get; set; }

        public int IDTipoGasto { get; set; }
        public TipoGasto TipoGastoAsociado { get; set; }

        public Pago() { }

        public Pago(MetodoPago metodoPago, int IDTipoGasto, TipoGasto tipoGastoAsociado, int IDUsuario, Usuario usuario, DescripcionPago descripcionPago)
        {
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
