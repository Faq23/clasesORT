using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetAllPagosRecurrentes : ICUGetAll<PagoRecurrenteDTOListado>
    {
        private IRepositorioPagoRecurrente _repo;

        public GetAllPagosRecurrentes(IRepositorioPagoRecurrente repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoRecurrenteDTOListado> Execute()
        {
            return PagoMapper.ToListDTO(_repo.GetAll());
        }
    }
}
