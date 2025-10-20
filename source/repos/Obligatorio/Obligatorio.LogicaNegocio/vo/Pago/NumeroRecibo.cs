using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Pago
{
    public record NumeroRecibo : IValidable
    {
        public int Value { get; private set; }

        public NumeroRecibo(int value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            if (Value <= 0)
            {
                throw new NumeroReciboException();
            }
        }
    }
}
