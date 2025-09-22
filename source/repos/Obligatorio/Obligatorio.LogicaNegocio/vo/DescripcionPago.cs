using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public class DescripcionPago : IValidable
    {
        public string Value { get; private set; }

        public DescripcionPago(string value)
        {
            Value = value;

            Validar();
        }
        public void Validar()
        {
            throw new DescripcionPagoException();
        }
    }
}
