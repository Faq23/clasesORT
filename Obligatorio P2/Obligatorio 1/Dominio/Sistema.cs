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

        // Properties

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();

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

            Usuarios.Add(c1);
            Usuarios.Add(c2);
            Usuarios.Add(c3);
            Usuarios.Add(c4);
            Usuarios.Add(c5);
            Usuarios.Add(c6);
            Usuarios.Add(c7);
            Usuarios.Add(c8);
            Usuarios.Add(c9);
            Usuarios.Add(c10);

            Usuarios.Add(ad1);
            Usuarios.Add(ad2);


            // Creación de 50 artículos
            Articulo a1 = new Articulo("Laptop", "Electronica", 1200);
            Articulo a2 = new Articulo("Smartphone", "Electronica", 800);
            Articulo a3 = new Articulo("Tablet", "Electronica", 400);
            Articulo a4 = new Articulo("Auriculares", "Electronica", 150);
            Articulo a5 = new Articulo("Teclado Mecánico", "Accesorios", 100);
            Articulo a6 = new Articulo("Mouse Gamer", "Accesorios", 80);
            Articulo a7 = new Articulo("Monitor 24''", "Electronica", 250);
            Articulo a8 = new Articulo("Cámara Fotográfica", "Electronica", 900);
            Articulo a9 = new Articulo("Smartwatch", "Electronica", 300);
            Articulo a10 = new Articulo("Impresora", "Oficina", 200);

            Articulo a11 = new Articulo("Silla de Oficina", "Muebles", 150);
            Articulo a12 = new Articulo("Escritorio", "Muebles", 300);
            Articulo a13 = new Articulo("Lámpara de Escritorio", "Iluminación", 50);
            Articulo a14 = new Articulo("Estantería", "Muebles", 200);
            Articulo a15 = new Articulo("Cafetera", "Electrodomésticos", 100);
            Articulo a16 = new Articulo("Microondas", "Electrodomésticos", 150);
            Articulo a17 = new Articulo("Refrigerador", "Electrodomésticos", 1000);
            Articulo a18 = new Articulo("Lavadora", "Electrodomésticos", 900);
            Articulo a19 = new Articulo("Aspiradora", "Electrodomésticos", 200);
            Articulo a20 = new Articulo("Plancha", "Electrodomésticos", 70);

            Articulo a21 = new Articulo("Televisor 55''", "Electronica", 1300);
            Articulo a22 = new Articulo("Barra de Sonido", "Electronica", 250);
            Articulo a23 = new Articulo("Proyector", "Electronica", 600);
            Articulo a24 = new Articulo("Cámara de Seguridad", "Seguridad", 180);
            Articulo a25 = new Articulo("Termómetro Digital", "Salud", 40);
            Articulo a26 = new Articulo("Bicicleta Estática", "Deportes", 350);
            Articulo a27 = new Articulo("Cinta para Correr", "Deportes", 800);
            Articulo a28 = new Articulo("Pesas", "Deportes", 100);
            Articulo a29 = new Articulo("Pelota de Yoga", "Deportes", 50);
            Articulo a30 = new Articulo("Cuerda para Saltar", "Deportes", 20);

            Articulo a31 = new Articulo("Juego de Sábanas", "Hogar", 80);
            Articulo a32 = new Articulo("Colchón", "Hogar", 600);
            Articulo a33 = new Articulo("Almohada", "Hogar", 30);
            Articulo a34 = new Articulo("Cobertor", "Hogar", 120);
            Articulo a35 = new Articulo("Cortinas", "Hogar", 90);
            Articulo a36 = new Articulo("Mesa de Comedor", "Muebles", 700);
            Articulo a37 = new Articulo("Juego de Sillas", "Muebles", 400);
            Articulo a38 = new Articulo("Sofá", "Muebles", 1000);
            Articulo a39 = new Articulo("Reloj de Pared", "Decoración", 60);
            Articulo a40 = new Articulo("Espejo", "Decoración", 120);

            Articulo a41 = new Articulo("Libro de Cuentos", "Libros", 25);
            Articulo a42 = new Articulo("Novela", "Libros", 30);
            Articulo a43 = new Articulo("Enciclopedia", "Libros", 120);
            Articulo a44 = new Articulo("Diccionario", "Libros", 40);
            Articulo a45 = new Articulo("Agenda", "Papelería", 15);
            Articulo a46 = new Articulo("Lápices de Colores", "Papelería", 10);
            Articulo a47 = new Articulo("Cuaderno", "Papelería", 5);
            Articulo a48 = new Articulo("Bolígrafo", "Papelería", 3);
            Articulo a49 = new Articulo("Tijeras", "Papelería", 8);
            Articulo a50 = new Articulo("Goma de Borrar", "Papelería", 2);

            // Agregar artículos al sistema
            Articulos.Add(a1);
            Articulos.Add(a2);
            Articulos.Add(a3);
            Articulos.Add(a4);
            Articulos.Add(a5);
            Articulos.Add(a6);
            Articulos.Add(a7);
            Articulos.Add(a8);
            Articulos.Add(a9);
            Articulos.Add(a10);
            Articulos.Add(a11);
            Articulos.Add(a12);
            Articulos.Add(a13);
            Articulos.Add(a14);
            Articulos.Add(a15);
            Articulos.Add(a16);
            Articulos.Add(a17);
            Articulos.Add(a18);
            Articulos.Add(a19);
            Articulos.Add(a20);
            Articulos.Add(a21);
            Articulos.Add(a22);
            Articulos.Add(a23);
            Articulos.Add(a24);
            Articulos.Add(a25);
            Articulos.Add(a26);
            Articulos.Add(a27);
            Articulos.Add(a28);
            Articulos.Add(a29);
            Articulos.Add(a30);
            Articulos.Add(a31);
            Articulos.Add(a32);
            Articulos.Add(a33);
            Articulos.Add(a34);
            Articulos.Add(a35);
            Articulos.Add(a36);
            Articulos.Add(a37);
            Articulos.Add(a38);
            Articulos.Add(a39);
            Articulos.Add(a40);
            Articulos.Add(a41);
            Articulos.Add(a42);
            Articulos.Add(a43);
            Articulos.Add(a44);
            Articulos.Add(a45);
            Articulos.Add(a46);
            Articulos.Add(a47);
            Articulos.Add(a48);
            Articulos.Add(a49);
            Articulos.Add(a50);

            // Creación de 10 ventas
            Venta v1 = new Venta("Venta 1", new List<Articulo> { a1, a2, a3 }, a1.Precio + a2.Precio + a3.Precio);
            Venta v2 = new Venta("Venta 2", new List<Articulo> { a4, a5, a6, a7 }, a4.Precio + a5.Precio + a6.Precio + a7.Precio);
            Venta v3 = new Venta("Venta 3", new List<Articulo> { a8, a9, a10 }, a8.Precio + a9.Precio + a10.Precio);
            Venta v4 = new Venta("Venta 4", new List<Articulo> { a11, a12, a13, a14, a15 }, a11.Precio + a12.Precio + a13.Precio + a14.Precio + a15.Precio);
            Venta v5 = new Venta("Venta 5", new List<Articulo> { a16, a17, a18, a19 }, a16.Precio + a17.Precio + a18.Precio + a19.Precio);
            Venta v6 = new Venta("Venta 6", new List<Articulo> { a20, a21, a22, a23 }, a20.Precio + a21.Precio + a22.Precio + a23.Precio);
            Venta v7 = new Venta("Venta 7", new List<Articulo> { a24, a25, a26, a27, a28 }, a24.Precio + a25.Precio + a26.Precio + a27.Precio + a28.Precio);
            Venta v8 = new Venta("Venta 8", new List<Articulo> { a29, a30, a31, a32, a33, a34 }, a29.Precio + a30.Precio + a31.Precio + a32.Precio + a33.Precio + a34.Precio);
            Venta v9 = new Venta("Venta 9", new List<Articulo> { a35, a36, a37 }, a35.Precio + a36.Precio + a37.Precio);
            Venta v10 = new Venta("Venta 10", new List<Articulo> { a38, a39, a40, a41, a42 }, a38.Precio + a39.Precio + a40.Precio + a41.Precio + a42.Precio);

            // Agregar ventas al sistema
            Publicaciones.Add(v1);
            Publicaciones.Add(v2);
            Publicaciones.Add(v3);
            Publicaciones.Add(v4);
            Publicaciones.Add(v5);
            Publicaciones.Add(v6);
            Publicaciones.Add(v7);
            Publicaciones.Add(v8);
            Publicaciones.Add(v9);
            Publicaciones.Add(v10);

            // Creación de 10 subastas sin repetir artículos de ventas
            Subasta s1 = new Subasta("Subasta 1", new List<Articulo> { a11, a12, a13 });
            Subasta s2 = new Subasta("Subasta 2", new List<Articulo> { a14, a15, a16, a17 });
            Subasta s3 = new Subasta("Subasta 3", new List<Articulo> { a18, a19, a20 });
            Subasta s4 = new Subasta("Subasta 4", new List<Articulo> { a21, a22, a23, a24 });
            Subasta s5 = new Subasta("Subasta 5", new List<Articulo> { a25, a26, a27 });
            Subasta s6 = new Subasta("Subasta 6", new List<Articulo> { a28, a29, a30, a31 });
            Subasta s7 = new Subasta("Subasta 7", new List<Articulo> { a32, a33, a34 });
            Subasta s8 = new Subasta("Subasta 8", new List<Articulo> { a35, a36, a37, a38 });
            Subasta s9 = new Subasta("Subasta 9", new List<Articulo> { a39, a40, a41 });
            Subasta s10 = new Subasta("Subasta 10", new List<Articulo> { a42, a43, a44, a45, a46 });

            s10.AgregarOferta(c2, 1000);
            s10.AgregarOferta(c3, 1500);
            s3.AgregarOferta(c7, 3000);

            // Modifico FechaPublicacion de algunas publicaciones para obtener diferentes resultados
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

            // Agregar subastas al sistema
            Publicaciones.Add(s1);
            Publicaciones.Add(s2);
            Publicaciones.Add(s3);
            Publicaciones.Add(s4);
            Publicaciones.Add(s5);
            Publicaciones.Add(s6);
            Publicaciones.Add(s7);
            Publicaciones.Add(s8);
            Publicaciones.Add(s9);
            Publicaciones.Add(s10);
        }

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
                publicacion.FinalizarPublicacion(cliente);
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
                subasta.FinalizarPublicacion(usuario);
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

        public List<Publicacion> ObtenerPublicacionesEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();

            foreach (Publicacion p in Publicaciones)
            {
                if (p.FechaPublicacion >= fechaInicio && p.FechaPublicacion <= fechaFin)
                {
                    publicaciones.Add(p);
                }
            }

            if (publicaciones.Count == 0)
            {
                throw new Exception("No existe ninguna publicación entre ese rango de fechas.");
            }

            return publicaciones;
        }
    }
}
