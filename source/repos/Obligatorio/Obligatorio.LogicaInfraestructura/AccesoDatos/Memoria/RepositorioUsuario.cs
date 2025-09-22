using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.Memoria
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new UsuarioException();
            }

            _usuarios.Add(obj);
        }

        public void Delete(int ID)
        {
            foreach (Usuario item in _usuarios)
            {
                if (item.ID.Equals(ID))
                {
                    _usuarios.Remove(item);
                }
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarios;
        }

        public Usuario GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
