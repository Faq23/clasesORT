using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;

namespace Obligatorio.LogicaAplicacion.dtos.Pagos
{
    public record PagoUnicoDTOListadoConSaldo(
        int ID,
        string Descripcion,
        int Monto,
        int IDUsuario,
        UsuarioDTOListado Usuario,
        string MetodoPago,
        int IDTipoGasto,
        TipoGastoDTOListado TipoGastoAsociado,
        DateTime FechaPago,
        int NumeroRecibo,
        int SaldoPendiente
        ) : PagoDTOListado(ID, Descripcion, Monto, IDUsuario, Usuario, MetodoPago, IDTipoGasto, TipoGastoAsociado)
    {
    }
}
