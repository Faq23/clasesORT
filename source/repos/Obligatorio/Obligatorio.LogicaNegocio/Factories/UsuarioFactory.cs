using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Factories
{
    public class UsuarioFactory : IFactory<Usuario>
    {
        public Usuario Crear(string tipo)
        {
            return tipo.ToLower() switch
            {
                "administrador" => new Administrador(),
                "gerente" => new Gerente(),
                "empleado" => new Empleado(),
                _ => throw new UsuarioException()
            };
        }
    }
}
