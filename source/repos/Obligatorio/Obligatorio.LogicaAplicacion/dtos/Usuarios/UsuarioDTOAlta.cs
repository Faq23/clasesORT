using Obligatorio.LogicaAplicacion.dtos.Equipos;

namespace Obligatorio.LogicaAplicacion.dtos.Usuarios
{
    public record UsuarioDTOAlta(
        string Nombre,
        string Apellido,
        string Contrasena,
        string Email,
        int IDEquipo,
        EquipoDTOListado Equipo,
        string Tipo)
    {
    }
}
