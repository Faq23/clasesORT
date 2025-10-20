using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Pago;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class ListarPagosRecurrentesMensual : ICUPagoMensualList<PagoRecurrenteDTOListadoConSaldo>
    {
        private IRepositorioPagoRecurrente _repo;

        public ListarPagosRecurrentesMensual(IRepositorioPagoRecurrente repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoRecurrenteDTOListadoConSaldo> Execute(int month, int year)
        {
            return PagoMapper.ToListDTOConSaldo(
                _repo.GetAll()
                .Where(p => p.FechaInicio.Month == month && p.FechaInicio.Year == year)
                );
        }
    }
}
