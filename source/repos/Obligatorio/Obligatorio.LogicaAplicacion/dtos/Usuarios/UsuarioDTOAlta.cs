using Obligatorio.LogicaAplicacion.dtos.Equipos;

namespace Obligatorio.LogicaAplicacion.dtos.Usuarios
{
    public record UsuarioDTOAlta(string Nombre, string Apellido, string Contrasena, string Email, int IDEquipo, EquipoDTOAlta Equipo, string Tipo)
    {
    }
}
