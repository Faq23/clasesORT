using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Pago
{
    public record DescripcionPago : IValidable
    {
        public string Value { get; private set; }

        public DescripcionPago(string value)
        {
            Value = value;

            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new DescripcionPagoException();
            }
        }
    }
}
