using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposGasto
{
    public class GetAllTipoGasto : ICUGetAll<TipoGastoDTOListado>
    {
        private IRepositorioTipoGasto _repo;

        public GetAllTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public IEnumerable<TipoGastoDTOListado> Execute()
        {
            return TipoGastoMapper.ToListDTO(_repo.GetAll());
        }
    }
}
