using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public static class EquipoMapper
    {
        public static Equipo FromDTO(EquipoDTOAlta equipoDTO)
        {
            return new Equipo(
                equipoDTO.ID,
                new NombreEquipo(equipoDTO.Nombre)); ;
        }

        public static EquipoDTOListado ToDTO(Equipo equipo)
        {
            return new EquipoDTOListado(
                    ID: equipo.ID,
                    Nombre: equipo.Nombre.Value
                    );
        }

        public static IEnumerable<EquipoDTOListado> ToListDTO(IEnumerable<Equipo> equipos)
        {
            List<EquipoDTOListado> aux = new List<EquipoDTOListado>();

            foreach (Equipo item in equipos)
            {
                aux.Add(ToDTO(item));
            }

            return aux;
        }
    }
}
