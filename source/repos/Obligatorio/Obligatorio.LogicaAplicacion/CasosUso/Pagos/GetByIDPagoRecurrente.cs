using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetByIDPagoRecurrente : ICUGetByID<PagoRecurrenteDTOListado>
    {
        private IRepositorioPagoRecurrente _repo;

        public GetByIDPagoRecurrente(IRepositorioPagoRecurrente repo)
        {
            _repo = repo;
        }
        public PagoRecurrenteDTOListado Execute(int id)
        {
            if (_repo.GetByID(id) != null) return PagoMapper.ToDTO(_repo.GetByID(id));

            return null;
        }
    }
}
