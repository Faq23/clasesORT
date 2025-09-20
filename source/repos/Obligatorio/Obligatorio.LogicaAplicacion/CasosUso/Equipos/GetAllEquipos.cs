using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipos
{
    public class GetAllEquipos : ICUGetAll<EquipoDTOListado>
    {
        private IRepositorioEquipo _repo;

        public GetAllEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<EquipoDTOListado> Execute()
        {
            return EquipoMapper.ToListDTO(_repo.GetAll()); ;
        }
    }
}
