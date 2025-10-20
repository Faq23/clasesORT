using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Auditoria : IEntity, IValidable
    {
        public int ID { get; set; }
        public DescripcionAuditoria Descripcion { get; set; }
        public NombreUsuarioAuditoria NombreUsuario { get; set; }
        public DateTime FechaAccion { get; set; }

        protected Auditoria() { }

        public Auditoria(DescripcionAuditoria descripcion, NombreUsuarioAuditoria nombreUsuario, DateTime fechaAccion)
        {
            Descripcion = descripcion;
            NombreUsuario = nombreUsuario;
            FechaAccion = fechaAccion;
        }

        public void Validar() { }
    }
}
