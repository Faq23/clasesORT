using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Usuario
{
    public record Nombre : IValidable
    {
        public string Value { get; private set; }

        public Nombre(string value)
        {
            Value = value;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreException();
            }
        }
    }
}
