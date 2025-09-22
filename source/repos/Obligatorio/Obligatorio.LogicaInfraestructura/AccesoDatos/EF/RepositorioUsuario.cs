using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ObligatorioContext _context;

        public RepositorioUsuario(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int ID)
        {
            foreach (Usuario item in _context.Usuarios)
            {
                if (item.ID.Equals(ID))
                {
                    _context.Usuarios.Remove(item);
                    break;
                }
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }

        public Usuario GetByID(int ID)
        {
            return _context.Usuarios.Single(usuario => usuario.ID == ID);
        }
    }
}
