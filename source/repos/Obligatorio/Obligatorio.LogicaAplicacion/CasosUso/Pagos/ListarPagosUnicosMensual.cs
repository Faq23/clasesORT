using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Pago;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class ListarPagosUnicosMensual : ICUPagoMensualList<PagoUnicoDTOListadoConSaldo>
    {
        private IRepositorioPagoUnico _repo;

        public ListarPagosUnicosMensual(IRepositorioPagoUnico repo)
        {
            _repo = repo;
        }
        public IEnumerable<PagoUnicoDTOListadoConSaldo> Execute(int month, int year)
        {
            return PagoMapper.ToListDTOConSaldo(
                _repo.GetAll()
                .Where(p => p.FechaPago.Month == month && p.FechaPago.Year == year)
                );
        }
    }
}
