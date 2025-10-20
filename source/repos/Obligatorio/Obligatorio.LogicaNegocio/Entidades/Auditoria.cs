using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo.Auditoria;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Auditoria : IEntity, IValidable
    {
        public int ID { get; set; }
        public DescripcionAuditoria Descripcion { get; set; }
        public EmailUsuarioAuditoria EmailUsuario { get; set; }
        public DateTime FechaAccion { get; set; }

        protected Auditoria() { }

        public Auditoria(DescripcionAuditoria descripcion, EmailUsuarioAuditoria emailUsuario, DateTime fechaAccion)
        {
            Descripcion = descripcion;
            EmailUsuario = emailUsuario;
            FechaAccion = fechaAccion;
        }

        public void Validar() { }
    }
}
