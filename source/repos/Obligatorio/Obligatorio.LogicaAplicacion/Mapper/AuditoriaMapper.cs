using Obligatorio.LogicaAplicacion.dtos.Auditorias;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class AuditoriaMapper
    {
        public static Auditoria FromDTO(AuditoriaDTOAlta auditoriaDTO)
        {
            return new Auditoria(
                new DescripcionAuditoria(auditoriaDTO.Descripcion),
                new NombreUsuarioAuditoria(auditoriaDTO.NombreUsuario),
                auditoriaDTO.FechaAccion);
        }
    }
}
