using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;

namespace Obligatorio.LogicaAplicacion.dtos.Pagos
{
    public record PagoDTOAlta(
        string Descripcion,
        int IDUsuario,
        UsuarioDTOAlta Usuario,
        string MetodoPago,
        int IDTipoGasto,
        TipoGastoDTOAlta TipoGastoAsociado)
    {
    }
}
