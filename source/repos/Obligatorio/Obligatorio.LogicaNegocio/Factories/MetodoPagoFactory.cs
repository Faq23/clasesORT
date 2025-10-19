using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.MetodoPago;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Factories
{
    public class MetodoPagoFactory : IFactory<MetodoPago>
    {
        public MetodoPago Crear(string tipo)
        {
            return tipo.ToLower() switch
            {
                "efectivo" => new Efectivo(),
                "credito" => new Credito(),
                _ => throw new MetodoPagoException()
            };
        }
    }
}
