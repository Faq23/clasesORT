using Obligatorio.LogicaAplicacion.dtos.Auditorias;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Auditorias
{
    public class AddAuditoria : ICUAdd<AuditoriaDTOAlta>
    {
        IRepositorioAuditoria _repo;

        public AddAuditoria(IRepositorioAuditoria repo)
        {
            _repo = repo;
        }

        public void Execute(AuditoriaDTOAlta obj)
        {
            _repo.Add(AuditoriaMapper.FromDTO(obj));
        }
    }
}
