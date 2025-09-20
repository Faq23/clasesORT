using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo
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
            throw new ApellidoException();
        }
    }
}
