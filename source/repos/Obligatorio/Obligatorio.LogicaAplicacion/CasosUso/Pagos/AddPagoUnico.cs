using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Pagos
{
    public class AddPagoUnico : ICUAdd<PagoUnicoDTOAlta>
    {
        private IRepositorioPagoUnico _repo;

        public AddPagoUnico(IRepositorioPagoUnico repo)
        {
            _repo = repo;
        }
        public void Execute(PagoUnicoDTOAlta obj)
        {
            _repo.Add(PagoMapper.FromDTO(obj));
        }
    }
}
