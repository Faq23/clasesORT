using Obligatorio.LogicaNegocio.vo.Pago;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime FechaPago { get; set; }
        public NumeroRecibo NumeroRecibo { get; set; }

        public PagoUnico() : base() { }

        public PagoUnico(MetodoPago metodoPago, int IDTipoGasto, TipoGasto tipoGastoAsociado, int IDUsuario, Usuario usuario, DescripcionPago descripcionPago, MontoPago montoPago, DateTime fechaPago, NumeroRecibo numeroRecibo)
            : base(metodoPago, IDTipoGasto, tipoGastoAsociado, IDUsuario, usuario, descripcionPago, montoPago)
        {
            FechaPago = fechaPago;
            NumeroRecibo = numeroRecibo;

            Validar();
        }
    }
}
