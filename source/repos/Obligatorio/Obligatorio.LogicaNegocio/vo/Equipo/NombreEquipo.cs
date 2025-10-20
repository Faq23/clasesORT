using Obligatorio.LogicaNegocio.Excepciones.Equipo;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.vo.Equipo
{
    public record NombreEquipo : IValidable
    {
        public string Value { get; private set; }

        public NombreEquipo(string value)
        {
            Value = value;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreEquipoException();
            }
        }
    }
}
