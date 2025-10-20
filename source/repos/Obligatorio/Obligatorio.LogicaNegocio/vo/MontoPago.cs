using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public record MontoPago : IValidable
    {
        public int Value { get; set; }

        public MontoPago(int value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            if (Value < 0)
            {
                throw new MontoPagoException();
            }
        }
    }
}
