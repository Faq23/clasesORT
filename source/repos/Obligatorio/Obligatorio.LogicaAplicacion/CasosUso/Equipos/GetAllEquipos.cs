using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaNegocio.Entidades;
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
            List<EquipoDTOListado> aux = new List<EquipoDTOListado>();

            foreach (Equipo e in _repo.GetAll())
            {
                aux.Add(new EquipoDTOListado(
                    ID: e.ID,
                    Nombre: e.Nombre.Value
                    ));
            }

            return aux;
        }
    }
}
