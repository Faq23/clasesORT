using Obligatorio.LogicaNegocio.Excepciones.Auditoria;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Auditoria
{
    public record EmailUsuarioAuditoria : IValidable
    {
        public string Value { get; private set; }

        public EmailUsuarioAuditoria(string value)
        {
            Value = value;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreUsuarioAuditoriaException();
            }
        }
    }
}
