using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipos
{
    public class GetByIDEquipo : ICUGetByID<EquipoDTOListado>
    {
        private IRepositorioEquipo _repo;
        public GetByIDEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public EquipoDTOListado Execute(int id)
        {
            return EquipoMapper.ToDTO(_repo.GetByID(id));
        }
    }
}
