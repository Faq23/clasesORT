using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.dtos.Usuarios
{
    public record UsuarioDTOAlta(string Nombre, string Apellido, string Contrasena, string Email, int IDEquipo, Equipo Equipo, string Tipo)
    {
    }
}
