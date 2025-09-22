using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
{
    public record Contrasena : IValidable
    {
        public string Value { get; private set; }

        public Contrasena(string value)
        {
            Value = value;
            Validar();

        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new ContrasenaException();
            }

            if (Value.Length < 8)
            {
                throw new ContrasenaException();
            }
        }
    }
}
