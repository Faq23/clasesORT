using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetAllPagosUnicos : ICUGetAll<PagoUnicoDTOListado>
    {
        private IRepositorioPagoUnico _repo;
        public GetAllPagosUnicos(IRepositorioPagoUnico repo)
        {
            _repo = repo;
        }
        public IEnumerable<PagoUnicoDTOListado> Execute()
        {
            return PagoMapper.ToListDTO(_repo.GetAll());
        }
    }
}
