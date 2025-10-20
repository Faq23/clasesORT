using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Usuario
{
    public record Apellido : IValidable
    {
        public string Value { get; private set; }

        public Apellido(string value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new ApellidoException();
            }
        }
    }
}
