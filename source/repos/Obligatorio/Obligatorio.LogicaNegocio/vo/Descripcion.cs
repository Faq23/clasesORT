using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public class Descripcion : IValidable
    {
        public string Value { get; private set; }

        public Descripcion(string value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
        }
    }
}
