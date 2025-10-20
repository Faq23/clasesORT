using Obligatorio.LogicaNegocio.Excepciones.Auditoria;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Auditoria
{
    public record DescripcionAuditoria : IValidable
    {
        public string Value { get; private set; }

        public DescripcionAuditoria(string value)
        {
            Value = value;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new DescripcionAuditoriaException();
            }
        }
    }
}
