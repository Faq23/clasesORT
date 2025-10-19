using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;

namespace Obligatorio.LogicaAplicacion.dtos.Pagos
{
    public record PagoUnicoDTOAlta(
        string Descripcion,
        int IDUsuario,
        UsuarioDTOAlta Usuario,
        string MetodoPago,
        int IDTipoGasto,
        TipoGastoDTOAlta TipoGastoAsociado,
        DateTime FechaPago,
        int NumeroRecibo
        ) : PagoDTOAlta(Descripcion, IDUsuario, Usuario, MetodoPago, IDTipoGasto, TipoGastoAsociado)
    {
    }
}
