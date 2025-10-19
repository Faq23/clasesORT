using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Factories;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class PagoMapper
    {
        public static PagoRecurrente FromDTO(PagoRecurrenteDTOAlta pagoDTO)
        {
            MetodoPagoFactory mpf = new MetodoPagoFactory();

            return new PagoRecurrente(
                    mpf.Crear(pagoDTO.MetodoPago),
                    pagoDTO.IDTipoGasto,
                    TipoGastoMapper.FromDTO(pagoDTO.TipoGastoAsociado),
                    pagoDTO.IDUsuario,
                    UsuarioMapper.FromDTO(pagoDTO.Usuario),
                    new DescripcionPago(pagoDTO.Descripcion),
                    pagoDTO.FechaInicio,
                    pagoDTO.FechaFin
                );
        }

        public static PagoUnico FromDTO(PagoUnicoDTOAlta pagoDTO)
        {
            MetodoPagoFactory mpf = new MetodoPagoFactory();

            return new PagoUnico(
                    mpf.Crear(pagoDTO.MetodoPago),
                    pagoDTO.IDTipoGasto,
                    TipoGastoMapper.FromDTO(pagoDTO.TipoGastoAsociado),
                    pagoDTO.IDUsuario,
                    UsuarioMapper.FromDTO(pagoDTO.Usuario),
                    new DescripcionPago(pagoDTO.Descripcion),
                    pagoDTO.FechaPago,
                    new NumeroRecibo(pagoDTO.NumeroRecibo)
                );
        }

        public static PagoRecurrenteDTOListado ToDTO(PagoRecurrente Pago)
        {
            return new PagoRecurrenteDTOListado(
                ID: Pago.ID,
                Descripcion: Pago.DescripcionPago.Value,
                IDUsuario: Pago.IDUsuario,
                Usuario: UsuarioMapper.ToDTO(Pago.Usuario),
                MetodoPago: Pago.MetodoPago.ToString(),
                IDTipoGasto: Pago.IDTipoGasto,
                TipoGastoAsociado: TipoGastoMapper.ToDTO(Pago.TipoGastoAsociado),
                FechaInicio: Pago.FechaInicio,
                FechaFin: Pago.FechaFin
                );
        }

        public static PagoUnicoDTOListado ToDTO(PagoUnico Pago)
        {
            return new PagoUnicoDTOListado(
                ID: Pago.ID,
                Descripcion: Pago.DescripcionPago.Value,
                IDUsuario: Pago.IDUsuario,
                Usuario: UsuarioMapper.ToDTO(Pago.Usuario),
                MetodoPago: Pago.MetodoPago.ToString(),
                IDTipoGasto: Pago.IDTipoGasto,
                TipoGastoAsociado: TipoGastoMapper.ToDTO(Pago.TipoGastoAsociado),
                FechaPago: Pago.FechaPago,
                NumeroRecibo: Pago.NumeroRecibo.Value
                );
        }

        public static IEnumerable<PagoRecurrenteDTOListado> ToListDTO(IEnumerable<PagoRecurrente> pagos)
        {
            List<PagoRecurrenteDTOListado> aux = new List<PagoRecurrenteDTOListado>();

            foreach (PagoRecurrente item in pagos)
            {
                aux.Add(ToDTO(item));
            }

            return aux;
        }

        public static IEnumerable<PagoUnicoDTOListado> ToListDTO(IEnumerable<PagoUnico> pagos)
        {
            List<PagoUnicoDTOListado> aux = new List<PagoUnicoDTOListado>();

            foreach (PagoUnico item in pagos)
            {
                aux.Add(ToDTO(item));
            }

            return aux;
        }
    }
}
