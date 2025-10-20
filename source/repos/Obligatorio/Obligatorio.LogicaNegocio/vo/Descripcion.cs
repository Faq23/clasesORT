using Obligatorio.LogicaNegocio.Excepciones.TipoGasto;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public record Descripcion : IValidable
    {
        public string Value { get; private set; }

        public Descripcion(string value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new DescripcionException();
            }
        }
    }
}
