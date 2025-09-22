using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime FechaPago { get; set; }
        public NumeroRecibo NumeroRecibo { get; set; }

        public PagoUnico(int id, MetodoPago metodoPago, TipoGasto tipoGastoAsociado, Usuario usuario, DescripcionPago descripcionPago, DateTime fechaPago, NumeroRecibo numeroRecibo) : base(id, metodoPago, tipoGastoAsociado, usuario, descripcionPago)
        {
            FechaPago = fechaPago;
            NumeroRecibo = numeroRecibo;

            Validar();
        }
    }
}
