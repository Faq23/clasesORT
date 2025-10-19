using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class GetByIDPagoUnico : ICUGetByID<PagoUnicoDTOListado>
    {
        private IRepositorioPagoUnico _repo;

        public GetByIDPagoUnico(IRepositorioPagoUnico repo)
        {
            _repo = repo;
        }
        public PagoUnicoDTOListado Execute(int id)
        {
            return PagoMapper.ToDTO(_repo.GetByID(id));
        }
    }
}
