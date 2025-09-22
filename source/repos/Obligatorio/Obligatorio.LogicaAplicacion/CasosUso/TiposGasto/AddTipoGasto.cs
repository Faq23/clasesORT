using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposGasto
{
    public class AddTipoGasto : ICUAdd<TipoGastoDTOAlta>
    {
        private IRepositorioTipoGasto _repo;

        public AddTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public void Execute(TipoGastoDTOAlta obj)
        {
            _repo.Add(TipoGastoMapper.FromDTO(obj));
        }
    }
}
