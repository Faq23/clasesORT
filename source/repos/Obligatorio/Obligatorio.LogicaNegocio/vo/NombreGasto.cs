using Obligatorio.LogicaNegocio.Excepciones.TipoGasto;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public class NombreGasto : IValidable
    {
        public string Value { get; private set; }

        public NombreGasto(string value)
        {
            Value = value;
        }
        public void Validar()
        {
            throw new NombreGastoException();
        }
    }
}
