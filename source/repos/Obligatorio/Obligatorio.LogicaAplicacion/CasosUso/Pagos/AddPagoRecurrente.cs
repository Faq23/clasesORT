using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class AddPagoRecurrente : ICUAdd<PagoRecurrenteDTOAlta>
    {
        private IRepositorioPagoRecurrente _repo;
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;
        public AddPagoRecurrente(
            IRepositorioPagoRecurrente repo,
            IRepositorioTipoGasto repoTipoGasto,
            IRepositorioUsuario repoUsuraio)
        {
            _repo = repo;
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuraio;
        }

        public void Execute(PagoRecurrenteDTOAlta obj)
        {
            _repo.Add(PagoMapper.FromDTO(
                obj,
                _repoTipoGasto.GetByID(obj.IDTipoGasto),
                _repoUsuario.GetByID(obj.IDUsuario)));
        }
    }
}
