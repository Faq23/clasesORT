using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime FechaPago { get; set; }
        public NumeroRecibo NumeroRecibo { get; set; }

        public PagoUnico() : base() { }

        public PagoUnico(MetodoPago metodoPago, int IDTipoGasto, TipoGasto tipoGastoAsociado, int IDUsuario, Usuario usuario, DescripcionPago descripcionPago, DateTime fechaPago, NumeroRecibo numeroRecibo)
            : base(metodoPago, IDTipoGasto, tipoGastoAsociado, IDUsuario, usuario, descripcionPago)
        {
            FechaPago = fechaPago;
            NumeroRecibo = numeroRecibo;

            Validar();
        }
    }
}
