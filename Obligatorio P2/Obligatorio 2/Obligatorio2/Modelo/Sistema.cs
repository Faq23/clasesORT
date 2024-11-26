using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Modelo
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

        // Properties

        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();

        private Sistema()
        {
            Precarga();
        }

        // Metodos

        private void Precarga()
        {
            // Creación de 10 clientes
            Cliente c1 = new Cliente(5000, "Juan", "Pérez", "juan.perez@gmail.com", "Password123$");
            Cliente c2 = new Cliente(3000, "María", "López", "maria.lopez@gmail.com", "Password123$");
            Cliente c3 = new Cliente(1500, "Carlos", "Gómez", "carlos.gomez@gmail.com", "Password123$");
            Cliente c4 = new Cliente(2500, "Ana", "Martínez", "ana.martinez@gmail.com", "Password123$");
            Cliente c5 = new Cliente(6000, "Pedro", "García", "pedro.garcia@gmail.com", "Password123$");
            Cliente c6 = new Cliente(4000, "Sofía", "Ramírez", "sofia.ramirez@gmail.com", "Password123$");
            Cliente c7 = new Cliente(3500, "Luis", "Fernández", "luis.fernandez@gmail.com", "Password123$");
            Cliente c8 = new Cliente(4500, "Lucía", "Hernández", "lucia.hernandez@gmail.com", "Password123$");
            Cliente c9 = new Cliente(2000, "Javier", "Ruiz", "javier.ruiz@gmail.com", "Password123$");
            Cliente c10 = new Cliente(5500, "Clara", "Morales", "clara.morales@gmail.com", "Password123$");

            // Creación de 2 administradores
            Administrador ad1 = new Administrador("Laura", "González", "laura.gonzalez@gmail.com", "Password123$");
            Administrador ad2 = new Administrador("Ricardo", "Santos", "ricardo.santos@gmail.com", "Password123$");

            // Agregar clientes y administradores al sistema

            _usuarios.Add(c1);
            _usuarios.Add(c2);
            _usuarios.Add(c3);
            _usuarios.Add(c4);
            _usuarios.Add(c5);
            _usuarios.Add(c6);
            _usuarios.Add(c7);
            _usuarios.Add(c8);
            _usuarios.Add(c9);
            _usuarios.Add(c10);

            _usuarios.Add(ad1);
            _usuarios.Add(ad2);

            // Creación de 50 artículos
            Articulo a1 = new Articulo("Laptop", "Electronica", 1200);
            Articulo a2 = new Articulo("Smartphone", "Electronica", 800);
            Articulo a3 = new Articulo("Tablet", "Electronica", 400);
            Articulo a4 = new Articulo("Auriculares", "Electronica", 150);
            Articulo a5 = new Articulo("Teclado Mecanico", "Accesorios", 100);
            Articulo a6 = new Articulo("Mouse Gamer", "Accesorios", 80);
            Articulo a7 = new Articulo("Monitor 24''", "Electronica", 250);
            Articulo a8 = new Articulo("Camara Fotografica", "Electronica", 900);
            Articulo a9 = new Articulo("Smartwatch", "Electronica", 300);
            Articulo a10 = new Articulo("Impresora", "Oficina", 200);

            Articulo a11 = new Articulo("Silla de Oficina", "Muebles", 150);
            Articulo a12 = new Articulo("Escritorio", "Muebles", 300);
            Articulo a13 = new Articulo("Lampara de Escritorio", "Iluminacion", 50);
            Articulo a14 = new Articulo("Estantería", "Muebles", 200);
            Articulo a15 = new Articulo("Cafetera", "Electrodomesticos", 100);
            Articulo a16 = new Articulo("Microondas", "Electrodomesticos", 150);
            Articulo a17 = new Articulo("Refrigerador", "Electrodomesticos", 1000);
            Articulo a18 = new Articulo("Lavadora", "Electrodomesticos", 900);
            Articulo a19 = new Articulo("Aspiradora", "Electrodomesticos", 200);
            Articulo a20 = new Articulo("Plancha", "Electrodomesticos", 70);

            Articulo a21 = new Articulo("Televisor 55''", "Electronica", 1300);
            Articulo a22 = new Articulo("Barra de Sonido", "Electronica", 250);
            Articulo a23 = new Articulo("Proyector", "Electronica", 600);
            Articulo a24 = new Articulo("Camara de Seguridad", "Seguridad", 180);
            Articulo a25 = new Articulo("Termometro Digital", "Salud", 40);
            Articulo a26 = new Articulo("Bicicleta Estática", "Deportes", 350);
            Articulo a27 = new Articulo("Cinta para Correr", "Deportes", 800);
            Articulo a28 = new Articulo("Pesas", "Deportes", 100);
            Articulo a29 = new Articulo("Pelota de Yoga", "Deportes", 50);
            Articulo a30 = new Articulo("Cuerda para Saltar", "Deportes", 20);

            Articulo a31 = new Articulo("Juego de Sábanas", "Hogar", 80);
            Articulo a32 = new Articulo("Colchon", "Hogar", 600);
            Articulo a33 = new Articulo("Almohada", "Hogar", 30);
            Articulo a34 = new Articulo("Cobertor", "Hogar", 120);
            Articulo a35 = new Articulo("Cortinas", "Hogar", 90);
            Articulo a36 = new Articulo("Mesa de Comedor", "Muebles", 700);
            Articulo a37 = new Articulo("Juego de Sillas", "Muebles", 400);
            Articulo a38 = new Articulo("Sofa", "Muebles", 1000);
            Articulo a39 = new Articulo("Reloj de Pared", "Decoracion", 60);
            Articulo a40 = new Articulo("Espejo", "Decoracion", 120);

            Articulo a41 = new Articulo("Libro de Cuentos", "Libros", 25);
            Articulo a42 = new Articulo("Novela", "Libros", 30);
            Articulo a43 = new Articulo("Enciclopedia", "Libros", 120);
            Articulo a44 = new Articulo("Diccionario", "Libros", 40);
            Articulo a45 = new Articulo("Agenda", "Papeleria", 15);
            Articulo a46 = new Articulo("Lápices de Colores", "Papeleria", 10);
            Articulo a47 = new Articulo("Cuaderno", "Papeleria", 5);
            Articulo a48 = new Articulo("Bolígrafo", "Papeleria", 3);
            Articulo a49 = new Articulo("Tijeras", "Papeleria", 8);
            Articulo a50 = new Articulo("Goma de Borrar", "Papeleria", 2);

            // Agregar artículos al sistema
            _articulos.Add(a1);
            _articulos.Add(a2);
            _articulos.Add(a3);
            _articulos.Add(a4);
            _articulos.Add(a5);
            _articulos.Add(a6);
            _articulos.Add(a7);
            _articulos.Add(a8);
            _articulos.Add(a9);
            _articulos.Add(a10);
            _articulos.Add(a11);
            _articulos.Add(a12);
            _articulos.Add(a13);
            _articulos.Add(a14);
            _articulos.Add(a15);
            _articulos.Add(a16);
            _articulos.Add(a17);
            _articulos.Add(a18);
            _articulos.Add(a19);
            _articulos.Add(a20);
            _articulos.Add(a21);
            _articulos.Add(a22);
            _articulos.Add(a23);
            _articulos.Add(a24);
            _articulos.Add(a25);
            _articulos.Add(a26);
            _articulos.Add(a27);
            _articulos.Add(a28);
            _articulos.Add(a29);
            _articulos.Add(a30);
            _articulos.Add(a31);
            _articulos.Add(a32);
            _articulos.Add(a33);
            _articulos.Add(a34);
            _articulos.Add(a35);
            _articulos.Add(a36);
            _articulos.Add(a37);
            _articulos.Add(a38);
            _articulos.Add(a39);
            _articulos.Add(a40);
            _articulos.Add(a41);
            _articulos.Add(a42);
            _articulos.Add(a43);
            _articulos.Add(a44);
            _articulos.Add(a45);
            _articulos.Add(a46);
            _articulos.Add(a47);
            _articulos.Add(a48);
            _articulos.Add(a49);
            _articulos.Add(a50);

            // Creación de 10 ventas
            Venta v1 = new Venta("Combo Setup 1", new List<Articulo> { a1, a2, a3 }, a1.Precio + a2.Precio + a3.Precio);
            Venta v2 = new Venta("Combo Setup 2", new List<Articulo> { a4, a5, a6, a7 }, a4.Precio + a5.Precio + a6.Precio + a7.Precio);
            Venta v3 = new Venta("Combo Fotografia", new List<Articulo> { a8, a9, a10 }, a8.Precio + a9.Precio + a10.Precio);
            Venta v4 = new Venta("Escritorio completo", new List<Articulo> { a11, a12, a13, a14 }, a11.Precio + a12.Precio + a13.Precio + a14.Precio);
            Venta v5 = new Venta("Combo Electrodomesticos 1", new List<Articulo> { a15, a16, a17, a18, a19 }, a15.Precio + a16.Precio + a17.Precio + a18.Precio + a19.Precio);
            Venta v6 = new Venta("Combo Electrodomesticos 2", new List<Articulo> { a20, a21, a22, a23 }, a20.Precio + a21.Precio + a22.Precio + a23.Precio);
            Venta v7 = new Venta("Combo Gimnasio", new List<Articulo> { a24, a25, a26, a27, a28 }, a24.Precio + a25.Precio + a26.Precio + a27.Precio + a28.Precio);
            Venta v8 = new Venta("Mistery Box Hogar 1", new List<Articulo> { a29, a30, a31, a32, a33, a34 }, a29.Precio + a30.Precio + a31.Precio + a32.Precio + a33.Precio + a34.Precio);
            Venta v9 = new Venta("Mistery Box Hogar 2", new List<Articulo> { a35, a36, a37 }, a35.Precio + a36.Precio + a37.Precio);
            Venta v10 = new Venta("Mistery Box Hogar 3", new List<Articulo> { a38, a39, a40, a41, a42 }, a38.Precio + a39.Precio + a40.Precio + a41.Precio + a42.Precio);

            v5.Estado = Estado.Cerrada;

            // Agregar ventas al sistema
            _publicaciones.Add(v1);
            _publicaciones.Add(v2);
            _publicaciones.Add(v3);
            _publicaciones.Add(v4);
            _publicaciones.Add(v5);
            _publicaciones.Add(v6);
            _publicaciones.Add(v7);
            _publicaciones.Add(v8);
            _publicaciones.Add(v9);
            _publicaciones.Add(v10);

            // Creación de 10 subastas sin repetir artículos de ventas
            Subasta s1 = new Subasta("Combo completo para escritorio", new List<Articulo> { a11, a12, a13 });
            Subasta s2 = new Subasta("Combo completo para cocina", new List<Articulo> { a14, a15, a16, a17 });
            Subasta s3 = new Subasta("Combo para limpieza", new List<Articulo> { a18, a19, a20 });
            Subasta s4 = new Subasta("Cine en casa", new List<Articulo> { a21, a22, a23, a24 });
            Subasta s5 = new Subasta("Combo Deporte para casa 1", new List<Articulo> { a25, a26, a27 });
            Subasta s6 = new Subasta("Combo Deporte para casa 2", new List<Articulo> { a28, a29, a30 });
            Subasta s7 = new Subasta("Combo para dormitorio", new List<Articulo> { a31, a32, a33, a34 });
            Subasta s8 = new Subasta("Combo para living-comedor", new List<Articulo> { a35, a36, a37, a38 });
            Subasta s9 = new Subasta("Decoracion para hall", new List<Articulo> { a39, a40 });
            Subasta s10 = new Subasta("Combo libreria", new List<Articulo> { a41, a42, a43, a44, a45, a46 });

            s10.AgregarOferta(c2, 1000);
            s10.AgregarOferta(c3, 1500);
            s3.AgregarOferta(c7, 3000);

            // Modifico FechaPublicacion de algunas _publicaciones para obtener diferentes resultados
            v2.FechaPublicacion = new DateTime(2024, 08, 10);
            v5.FechaPublicacion = new DateTime(2024, 05, 23);
            v7.FechaPublicacion = new DateTime(2024, 11, 23);
            v10.FechaPublicacion = new DateTime(2024, 03, 01);
            v3.FechaPublicacion = new DateTime(2024, 08, 09);
            s2.FechaPublicacion = new DateTime(2024, 07, 20);
            s5.FechaPublicacion = new DateTime(2024, 07, 20);
            s4.FechaPublicacion = new DateTime(2024, 01, 31);
            s9.FechaPublicacion = new DateTime(2024, 02, 29);
            s1.FechaPublicacion = new DateTime(2024, 07, 20);

            s1.Estado = Estado.Cancelada;
            s4.Estado = Estado.Cancelada;

            // Agregar subastas al sistema
            _publicaciones.Add(s1);
            _publicaciones.Add(s2);
            _publicaciones.Add(s3);
            _publicaciones.Add(s4);
            _publicaciones.Add(s5);
            _publicaciones.Add(s6);
            _publicaciones.Add(s7);
            _publicaciones.Add(s8);
            _publicaciones.Add(s9);
            _publicaciones.Add(s10);
        }

        #region Getters

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        public IEnumerable<Articulo> ObtenerArticulos()
        {
            return _articulos;
        }
        public IEnumerable<Publicacion> ObtenerPublicaciones()
        {
            return _publicaciones;
        }

        #endregion

        #region Login/Register
        public Usuario LogInUser(string email, string password)
        {
            Usuario?
                user = null;
            bool foundUser = false;

            foreach (Usuario u in _usuarios)
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

        public void RegistrarCliente(Cliente c)
        {
            if (ValidarUsuarioExistente(c.Email))
            {
                throw new Exception("Ya existe un usuario con el correo ingresado.");
            }
            else
            {
                try
                {
                    AgregarUsuario(c.Nombre, c.Apellido, c.Email, c.Password, 0); // Cuando un usuario se registra como cliente su saldo comienza en 0.
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private bool ValidarUsuarioExistente(string userEmail)
        {
            bool found = false;

            foreach (Usuario u in _usuarios)
            {
                if (userEmail == u.Email)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        #endregion

        #region Usuarios

        public Usuario? ObtenerUsuarioPorID(int? userID)
        {
            Usuario? usuario = null;

            foreach (Usuario u in _usuarios)
            {
                if (u.ID == userID)
                {
                    usuario = u;
                    break;
                }
            }

            return usuario;
        }

        public void AgregarUsuario(string nombre, string apellido, string email, string password, int saldo = -1)
        {
            try
            {
                if (saldo > -1)
                {
                    Cliente newUser = new Cliente(saldo, nombre, apellido, email, password);
                    _usuarios.Add(newUser);
                }
                else
                {
                    Administrador newUser = new Administrador(nombre, apellido, email, password);
                    _usuarios.Add(newUser);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Publicaciones

        public void CrearPublicacion(string nombre, List<Articulo> _articulos, double valor = -1)
        {
            Publicacion newPublicacion;

            try
            {
                if (valor > -1) // Entiendo que si la publicacion tiene un valor se trata de una Venta, de lo contrario es una Subasta ya que el precio inicial es 0.
                {
                    newPublicacion = new Venta(nombre, _articulos, valor);
                }
                else
                {
                    newPublicacion = new Subasta(nombre, _articulos);
                }

                _publicaciones.Add(newPublicacion);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Publicacion> ObtenerPublicacionesEntreFechas(DateTime fechaInicio, DateTime fechaFin) // Metodo creado para el Obligatorio 1
        {
            List<Publicacion> _publicaciones = new List<Publicacion>();

            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublicacion >= fechaInicio && p.FechaPublicacion <= fechaFin)
                {
                    _publicaciones.Add(p);
                }
            }

            if (_publicaciones.Count == 0)
            {
                throw new Exception("No existe ninguna publicación entre ese rango de fechas.");
            }

            return _publicaciones;
        }

        public Publicacion? ObtenerPublicacionPorID(int ID)
        {
            Publicacion? publicacion = null;

            foreach (Publicacion p in _publicaciones)
            {
                if (p.ID == ID)
                {
                    publicacion = p;
                    break;
                }
            }

            return publicacion;
        }

        public IEnumerable<Publicacion> ObtenerPublicacionesPorFechaPubli()
        {
            List<Publicacion> listaPublicacionesFiltrada = _publicaciones;

            listaPublicacionesFiltrada.Sort(); // Utilizo Sort para ordenar la lista segun el CompareTo configurado en Publicacion, el mismo ordena por fecha publicacion de manera ascendente.

            return listaPublicacionesFiltrada;
        }

        #endregion

        #region Articulos

        // Estos metodos fueron realizados para el Obligatorio 1 pero no fue necesario utilizarlos para esta segunda parte.

        public void AgregarArticulo(string nombre, string categoria, double precio)
        {
            try
            {
                Articulo newArticulo = new Articulo(nombre, categoria, precio);
                _articulos.Add(newArticulo);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Articulo ObtenerArticulo(int idArticulo)
        {
            Articulo a = new Articulo();

            foreach (Articulo ar in _articulos)
            {
                if (ar.ID == idArticulo)
                {
                    a = ar;
                    break;
                }
            }

            return a;
        }

        public List<Articulo> ObtenerArticulosPorCategoria(string categoria) // Metodo para entrega de Obligatorio 1
        {
            List<Articulo> _articulos = new List<Articulo>();

            foreach (Articulo a in _articulos)
            {
                if (a.Categoria == categoria)
                {
                    _articulos.Add(a);
                }
            }

            if (_articulos.Count == 0)
            {
                throw new Exception("No existe ningun articulo que pertenezca a esa categoria.");
            }

            return _articulos;
        }

        #endregion
    }
}