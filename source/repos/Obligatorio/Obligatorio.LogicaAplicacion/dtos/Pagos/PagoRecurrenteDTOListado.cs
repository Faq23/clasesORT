using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;

namespace Obligatorio.LogicaAplicacion.dtos.Pagos
{
    public record PagoRecurrenteDTOListado(
        int ID,
        string Descripcion,
        int Monto,
        int IDUsuario,
        UsuarioDTOListado Usuario,
        string MetodoPago,
        int IDTipoGasto,
        TipoGastoDTOListado TipoGastoAsociado,
        DateTime FechaInicio,
        DateTime FechaFin
        ) : PagoDTOListado(ID, Descripcion, Monto, IDUsuario, Usuario, MetodoPago, IDTipoGasto, TipoGastoAsociado)
    {
    }
}
