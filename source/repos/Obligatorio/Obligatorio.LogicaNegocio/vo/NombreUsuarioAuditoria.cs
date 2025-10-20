using Obligatorio.LogicaNegocio.Excepciones.Auditoria;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public record NombreUsuarioAuditoria : IValidable
    {
        public string Value { get; private set; }

        public NombreUsuarioAuditoria(string value)
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
