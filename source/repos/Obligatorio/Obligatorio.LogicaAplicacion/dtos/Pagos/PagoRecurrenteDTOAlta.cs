using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;

namespace Obligatorio.LogicaAplicacion.dtos.Pagos
{
    public record PagoRecurrenteDTOAlta(
        string Descripcion,
        int IDUsuario,
        UsuarioDTOAlta Usuario,
        string MetodoPago,
        int IDTipoGasto,
        TipoGastoDTOAlta TipoGastoAsociado,
        DateTime FechaInicio,
        DateTime FechaFin
        ) : PagoDTOAlta(Descripcion, IDUsuario, Usuario, MetodoPago, IDTipoGasto, TipoGastoAsociado)
    {
    }
}
