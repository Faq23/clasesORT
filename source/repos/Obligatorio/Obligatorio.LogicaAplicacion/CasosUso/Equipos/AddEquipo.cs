using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.LogicaNegocio.vo;

namespace Obligatorio.LogicaAplicacion.CasosUso.Equipos
{
    public class AddEquipo : ICUAdd<EquipoDTOAlta>
    {
        private IRepositorioEquipo _repo;

        public AddEquipo(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public void Execute(EquipoDTOAlta obj)
        {
            Equipo e = new Equipo(obj.ID, new Nombre(obj.Nombre));
            _repo.Add(e);
        }
    }
}
