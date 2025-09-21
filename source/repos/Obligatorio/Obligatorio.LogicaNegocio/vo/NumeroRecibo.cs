using Obligatorio.LogicaNegocio.Excepciones.Pago;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public class NumeroRecibo : IValidable
    {
        public int Value { get; private set; }

        public NumeroRecibo(int value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            throw new NumeroReciboException();
        }
    }
}
