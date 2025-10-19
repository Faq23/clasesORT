using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class AddPagoRecurrente : ICUAdd<PagoRecurrenteDTOAlta>
    {
        private IRepositorioPagoRecurrente _repo;

        public AddPagoRecurrente(IRepositorioPagoRecurrente repo)
        {
            _repo = repo;
        }

        public void Execute(PagoRecurrenteDTOAlta obj)
        {
            _repo.Add(PagoMapper.FromDTO(obj));
        }
    }
}
