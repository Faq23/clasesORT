using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.TiposGasto
{
    public class DeleteTipoGasto : ICUDelete<TipoGastoDTOListado>
    {
        private IRepositorioTipoGasto _repo;
        public DeleteTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }
        public void Execute(int id)
        {
            _repo.Delete(id);
        }
    }
}
