using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.Equipo;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.Memoria
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private static List<Equipo> _equipos = new List<Equipo>();

        public void Add(Equipo obj)
        {
            if (obj == null)
            {
                throw new EquipoException();
            }
            _equipos.Add(obj);
        }

        public IEnumerable<Equipo> GetAll()
        {
            return _equipos;
        }

        public Equipo GetByID(int ID)
        {
            return _equipos[ID];
        }
    }
}
