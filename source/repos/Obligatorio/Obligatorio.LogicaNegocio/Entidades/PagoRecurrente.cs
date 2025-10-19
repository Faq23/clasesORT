using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public PagoRecurrente() : base() { }
        public PagoRecurrente(MetodoPago metodoPago, int IDTipoGasto, TipoGasto tipoGastoAsociado, int IDUsuario, Usuario usuario, DescripcionPago descripcionPago, DateTime fechaInicio, DateTime fechaFin)
            : base(metodoPago, IDTipoGasto, tipoGastoAsociado, IDUsuario, usuario, descripcionPago)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;

            Validar();
        }
    }
}
