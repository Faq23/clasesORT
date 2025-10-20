using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Factories;
using Obligatorio.LogicaNegocio.vo.Pago;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class PagoMapper
    {
        public static PagoRecurrente FromDTO(PagoRecurrenteDTOAlta pagoDTO, TipoGasto tipoGasto, Usuario usuario)
        {
            MetodoPagoFactory mpf = new MetodoPagoFactory();

            return new PagoRecurrente(
                    mpf.Crear(pagoDTO.MetodoPago),
                    pagoDTO.IDTipoGasto,
                    tipoGasto,
                    pagoDTO.IDUsuario,
                    usuario,
                    new DescripcionPago(pagoDTO.Descripcion),
                    new MontoPago(pagoDTO.Monto),
                    pagoDTO.FechaInicio,
                    pagoDTO.FechaFin
                );
        }

        public static PagoUnico FromDTO(PagoUnicoDTOAlta pagoDTO, TipoGasto tipoGasto, Usuario usuario)
        {
            MetodoPagoFactory mpf = new MetodoPagoFactory();

            return new PagoUnico(
                    mpf.Crear(pagoDTO.MetodoPago),
                    pagoDTO.IDTipoGasto,
                    tipoGasto,
                    pagoDTO.IDUsuario,
                    usuario,
                    new DescripcionPago(pagoDTO.Descripcion),
                    new MontoPago(pagoDTO.Monto),
                    pagoDTO.FechaPago,
                    new NumeroRecibo(pagoDTO.NumeroRecibo)
                );
        }

        public static PagoRecurrenteDTOListado ToDTO(PagoRecurrente Pago)
        {
            return new PagoRecurrenteDTOListado(
                ID: Pago.ID,
                Descripcion: Pago.DescripcionPago.Value,
                Monto: Pago.MontoPago.Value,
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
                Monto: Pago.MontoPago.Value,
                IDUsuario: Pago.IDUsuario,
                Usuario: UsuarioMapper.ToDTO(Pago.Usuario),
                MetodoPago: Pago.MetodoPago.ToString(),
                IDTipoGasto: Pago.IDTipoGasto,
                TipoGastoAsociado: TipoGastoMapper.ToDTO(Pago.TipoGastoAsociado),
                FechaPago: Pago.FechaPago,
                NumeroRecibo: Pago.NumeroRecibo.Value
                );
        }

        public static PagoRecurrenteDTOListadoConSaldo ToDTO(PagoRecurrente Pago, int montoTotal)
        {
            return new PagoRecurrenteDTOListadoConSaldo(
                ID: Pago.ID,
                Descripcion: Pago.DescripcionPago.Value,
                Monto: Pago.MontoPago.Value,
                IDUsuario: Pago.IDUsuario,
                Usuario: UsuarioMapper.ToDTO(Pago.Usuario),
                MetodoPago: Pago.MetodoPago.ToString(),
                IDTipoGasto: Pago.IDTipoGasto,
                TipoGastoAsociado: TipoGastoMapper.ToDTO(Pago.TipoGastoAsociado),
                FechaInicio: Pago.FechaInicio,
                FechaFin: Pago.FechaFin,
                SaldoPendiente: montoTotal
                );
        }

        public static PagoUnicoDTOListadoConSaldo ToDTO(PagoUnico Pago, int montoTotal)
        {
            return new PagoUnicoDTOListadoConSaldo(
                ID: Pago.ID,
                Descripcion: Pago.DescripcionPago.Value,
                Monto: Pago.MontoPago.Value,
                IDUsuario: Pago.IDUsuario,
                Usuario: UsuarioMapper.ToDTO(Pago.Usuario),
                MetodoPago: Pago.MetodoPago.ToString(),
                IDTipoGasto: Pago.IDTipoGasto,
                TipoGastoAsociado: TipoGastoMapper.ToDTO(Pago.TipoGastoAsociado),
                FechaPago: Pago.FechaPago,
                NumeroRecibo: Pago.NumeroRecibo.Value,
                SaldoPendiente: montoTotal
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

        public static IEnumerable<PagoRecurrenteDTOListadoConSaldo> ToListDTOConSaldo(IEnumerable<PagoRecurrente> pagos)
        {
            List<PagoRecurrenteDTOListadoConSaldo> aux = new List<PagoRecurrenteDTOListadoConSaldo>();

            foreach (PagoRecurrente item in pagos)
            {
                int mesesRestantes = (item.FechaFin.Year - DateTime.Now.Year) * 12
                                    + item.FechaFin.Month - DateTime.Now.Month
                                    - (DateTime.Now.Day > item.FechaFin.Day ? 1 : 0); // Esto es para redondear si el día exacto llegó o no.

                aux.Add(ToDTO
                    (item,
                    mesesRestantes * item.MontoPago.Value
                    )
                );
            }

            return aux;
        }

        public static IEnumerable<PagoUnicoDTOListadoConSaldo> ToListDTOConSaldo(IEnumerable<PagoUnico> pagos)
        {
            List<PagoUnicoDTOListadoConSaldo> aux = new List<PagoUnicoDTOListadoConSaldo>();

            foreach (PagoUnico item in pagos)
            {


                aux.Add(ToDTO(item, 0));
            }

            return aux;
        }
    }
}
