using Obligatorio.LogicaNegocio.Excepciones.TipoGasto;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.TipoGasto
{
    public record NombreGasto : IValidable
    {
        public string Value { get; private set; }

        public NombreGasto(string value)
        {
            Value = value;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreGastoException();
            }
        }
    }
}
