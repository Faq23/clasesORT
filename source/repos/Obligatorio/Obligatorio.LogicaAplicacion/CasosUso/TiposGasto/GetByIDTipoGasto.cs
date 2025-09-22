using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposGasto
{
    public class GetByIDTipoGasto : ICUGetByID<TipoGastoDTOListado>
    {
        private IRepositorioTipoGasto _repo;

        public GetByIDTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public TipoGastoDTOListado Execute(int id)
        {
            return TipoGastoMapper.ToDTO(_repo.GetByID(id));
        }
    }
}
