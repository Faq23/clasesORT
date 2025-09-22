using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public PagoRecurrente(int id, MetodoPago metodoPago, TipoGasto tipoGastoAsociado, Usuario usuario, DescripcionPago descripcionPago, DateTime fechaInicio, DateTime fechaFin) : base(id, metodoPago, tipoGastoAsociado, usuario, descripcionPago)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;

            Validar();
        }
    }
}
