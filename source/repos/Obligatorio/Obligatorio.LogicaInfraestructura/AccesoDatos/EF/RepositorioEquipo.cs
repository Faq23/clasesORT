using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private ObligatorioContext _context;

        public RepositorioEquipo(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Equipo obj)
        {
            _context.Equipos.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _context.Equipos;
        }

        public Equipo GetByID(int ID)
        {
            return _context.Equipos.Single(equipo => equipo.ID == ID);
        }
    }
}
