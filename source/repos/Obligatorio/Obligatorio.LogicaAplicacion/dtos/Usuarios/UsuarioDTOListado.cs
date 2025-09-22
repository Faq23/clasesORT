using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAplicacion.dtos.Usuarios
{
    public record UsuarioDTOListado(int ID, string Nombre, string Apellido, string Contrasena, string Email, int IDEquipo, Equipo Equipo, string Tipo)
    {
    }
}
