using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposGasto
{
    public class UpdateTipoGasto : ICUUpdate<TipoGastoDTOAlta>
    {
        private IRepositorioTipoGasto _repo;

        public UpdateTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public void Execute(int ID, TipoGastoDTOAlta obj)
        {
            _repo.Update(ID, TipoGastoMapper.FromDTO(obj));
        }
    }
}
