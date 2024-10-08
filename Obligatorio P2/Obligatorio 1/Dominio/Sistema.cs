using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instance;

        public static Sistema Instance
        {
            get
            {
                if (instance == null) instance = new Sistema();
                return instance;
            }
        }

        private Sistema() { }

        // Properties

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();

        // Metodos

        public void AgregarUsuario(string nombre, string apellido, string email, string password, int saldo = -1)
        {
            try
            {
                if (saldo > -1)
                {
                    Cliente newUser = new Cliente(saldo, nombre, apellido, email, password);
                    Usuarios.Add(newUser);
                }
                else
                {
                    Administrador newUser = new Administrador(nombre, apellido, email, password);
                    Usuarios.Add(newUser);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AgregarArticulo(string nombre, string categoria, int precio)
        {
            try
            {
                Articulo newArticulo = new Articulo(nombre, categoria, precio);
                Articulos.Add(newArticulo);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CrearPublicacion(string nombre, List<Articulo> articulos, int valor = -1)
        {
            Publicacion newPublicacion  = new Publicacion();

            try
            {
                if (valor > -1)
                {
                    newPublicacion = new Venta(nombre, articulos, valor);
                }
                else
                {
                    newPublicacion = new Subasta(nombre, articulos);
                }

                Publicaciones.Add(newPublicacion);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CrearOferta(Subasta subasta, int monto, Cliente cliente)
        {   
            try
            {
                subasta.AgregarOferta(cliente, monto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void AsociarCompra(Venta publicacion, Cliente cliente)
        {
            try
            {
                publicacion.FinalizarCompra(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ValidarSubasta(Subasta subasta, Administrador usuario) 
        {
            try
            {
                subasta.FinalizarSubasta(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ModificarOferta(Venta venta) 
        {
            try
            {
                venta.ModificarOferta();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void CancelarPublicacion(Publicacion publicacion, Administrador administrador) 
        {
            try
            {
                publicacion.CancelarPublicacion(administrador);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Usuario LogInUser(string email, string password)
        {
            Usuario user = new Usuario();
            bool foundUser = false;

            foreach (Usuario u in Usuarios)
            {
                if (u.Email == email)
                {
                    user = u;
                    foundUser = true; break;
                }
            }

            if (!foundUser)
            {
                throw new Exception("El email ingresado no pertenece a ningun usuario existente.");
            } 
            else
            {
                if (user.Password != password)
                {
                    throw new Exception("La contraseña ingresada no es correcta.");
                }
                else
                {
                    return user;
                }
            }
        }

        public Venta ObtenerVenta(int idVenta)
        {
            Venta p = new Venta();

            foreach (Publicacion v in Publicaciones)
            {
                if (v is Venta && v.ID == idVenta)
                {
                    p = v as Venta;
                    break;
                }
            }

            return p;
        }
        public Subasta ObtenerSubasta(int idSubasta)
        {
            Subasta p = new Subasta();

            foreach (Publicacion s in Publicaciones)
            {
                if (s is Subasta && s.ID == idSubasta)
                {
                    p = s as Subasta;
                    break;
                }
            }

            return p;
        }

        public Articulo ObtenerArticulo(int idArticulo)
        {
            Articulo a = new Articulo();

            foreach (Articulo ar in Articulos)
            {
                if (ar.ID == idArticulo)
                {
                    a = ar;
                    break;
                }
            }

            return a;
        }

        public List<Articulo> ObtenerArticulosPorCategoria(string categoria)
        {
            List<Articulo> articulos = new List<Articulo>();

            foreach(Articulo a in Articulos)
            {
                if (a.Categoria == categoria)
                {
                    articulos.Add(a);
                }
            }

            if (articulos.Count == 0)
            {
                throw new Exception("No existe ningun articulo que pertenezca a esa categoria.");
            }

            return articulos;
        }
    }
}
