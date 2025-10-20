using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;

namespace Obligatorio.LogicaAplicacion.dtos.Pagos
{
    public record PagoRecurrenteDTOAlta(
        string Descripcion,
        int Monto,
        int IDUsuario,
        UsuarioDTOListado Usuario,
        string MetodoPago,
        int IDTipoGasto,
        TipoGastoDTOListado TipoGastoAsociado,
        DateTime FechaInicio,
        DateTime FechaFin
        ) : PagoDTOAlta(Descripcion, Monto, IDUsuario, Usuario, MetodoPago, IDTipoGasto, TipoGastoAsociado)
    {
    }
}
