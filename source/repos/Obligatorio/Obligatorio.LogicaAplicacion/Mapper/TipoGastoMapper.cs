using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.Mapper
{
    public class TipoGastoMapper
    {
        public static TipoGasto FromDTO(TipoGastoDTOAlta tipoGastoDTO)
        {
            return new TipoGasto(
                new NombreGasto(tipoGastoDTO.Nombre),
                new Descripcion(tipoGastoDTO.Descripcion)
                );
        }

        public static TipoGasto existantFromDTO(TipoGastoDTOAlta tipoGastoDTO)
        {
            return new TipoGasto(
                new NombreGasto(tipoGastoDTO.Nombre),
                new Descripcion(tipoGastoDTO.Descripcion)
                );
        }


        public static TipoGastoDTOListado ToDTO(TipoGasto tipoGasto)
        {
            return new TipoGastoDTOListado(
                ID: tipoGasto.ID,
                Nombre: tipoGasto.NombreGasto.Value,
                Descripcion: tipoGasto.Descripcion.Value
                );
        }

        public static IEnumerable<TipoGastoDTOListado> ToListDTO(IEnumerable<TipoGasto> tiposGasto)
        {
            List<TipoGastoDTOListado> aux = new List<TipoGastoDTOListado>();

            foreach (TipoGasto item in tiposGasto)
            {
                aux.Add(ToDTO(item));
            }

            return aux;
        }
    }
}
