namespace Interfaz
{
    using Dominio;
    using System.Diagnostics.Tracing;
    using System.Runtime.InteropServices;

    internal class Program
    {
        Sistema system = Sistema.Instance;

        static void Main(string[] args)
        {
            Sistema system = Sistema.Instance;

            EntregaMenu();

            //int cont = 0;

            //while (cont < 5)
            //{

            //    try
            //    {
            //        Console.WriteLine("##### LOGIN USER #####");

            //        Console.WriteLine("Ingrese su email: ");
            //        string email = Console.ReadLine();

            //        Console.WriteLine("Ingrese su contraseña: ");
            //        string password = Console.ReadLine();

            //        Console.WriteLine("######################");

            //        Usuario userLogued = system.LogInUser(email, password);

            //        if (userLogued is Cliente)
            //        {
            //            Console.Clear();
            //            ClientMenu(userLogued as Cliente);
            //        }
            //        else
            //        {
            //            Console.Clear();
            //            AdminMenu(userLogued as Administrador);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        Console.WriteLine("Ha fallado " + cont + " veces en loguearse, tiene un limite de 5 intentos, al completarlos el programa se cerrará.");
            //    }

            //    cont++;
            //}

            Console.ReadKey();
        }

        private static void ClientMenu(Cliente userLogued)
        {
            Sistema system = Sistema.Instance;

            int exit = 0;

            while (exit == 0)
            {
                try
                {
                    Console.WriteLine("##### CLIENT MENU #####");

                    Console.WriteLine("1 - Ver ventas disponibles");
                    Console.WriteLine("2 - Ver subastas disponibles");
                    Console.WriteLine("3 - Ver mis datos");
                    Console.WriteLine("0 - Salir");

                    Console.WriteLine("#######################");

                    Console.WriteLine("Seleccione una opción: ");
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 0:
                            exit = 1;
                            break;
                        case 1:

                            try
                            {
                                Console.WriteLine("##### VENTAS #####");

                                foreach (Publicacion v in system.Publicaciones)
                                {
                                    if (v is Venta && v.Estado == Estado.Abierta)
                                    {
                                        Console.WriteLine(v.ID + " - " + v.Nombre);
                                    }
                                }

                                Console.WriteLine("##################");

                                Console.WriteLine("Ingrese el ID de la publicación que desea comprar: ");
                                int eleccion = int.Parse(Console.ReadLine());

                            
                                Venta venta = system.ObtenerVenta(eleccion);
                                userLogued.RealizarCompra(venta);

                                Console.WriteLine("La compra fue realizada con éxito.");
                                Console.ReadKey();

                            }
                            catch (Exception ex) 
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        case 2:

                            try
                            {
                                Console.WriteLine("##### SUBASTAS #####");

                                foreach (Publicacion s in system.Publicaciones)
                                {
                                    if (s is Subasta && s.Estado == Estado.Abierta)
                                    {
                                        Console.WriteLine(s.ID + " - " + s.Nombre);
                                    }
                                }

                                Console.WriteLine("####################");

                                Console.WriteLine("Ingrese el ID de la publicación a la cual desea ofertar: ");
                                int eleccion = int.Parse(Console.ReadLine());
                                
                                Console.WriteLine("Ingrese el monto que desea ofertar: ");
                                int monto = int.Parse(Console.ReadLine());

                                Subasta subasta = system.ObtenerSubasta(eleccion);
                                userLogued.CrearOferta(subasta, monto);

                                Console.WriteLine("La oferta fue realizada con éxito.");
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        case 3:

                            try
                            {
                                Console.WriteLine("##### MIS DATOS #####");

                                Console.WriteLine("Monto disponible en la cuenta: " + userLogued.Saldo);
                                Console.WriteLine("Mis ofertas activas:");

                                foreach (Publicacion s in system.Publicaciones)
                                {
                                    if (s is Subasta && s.Estado == Estado.Abierta)
                                    {
                                        Subasta su = s as Subasta;

                                        foreach (Oferta o in su.Ofertas)
                                        {
                                            if (o.Cliente == userLogued)
                                            {
                                                Console.WriteLine(o.ID + " - $" + o.Monto + " ofertado en la subasta: " + s.Nombre);
                                            }

                                        }
                                    }
                                }

                                Console.WriteLine("#####################");

                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        default:
                            Console.WriteLine("La opción ingresada no es valida, por favor vuelva a intentarlo");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

                Console.Clear();
            }
            
        }

        private void AdminMenu(Administrador userLogued)
        {
            Sistema system = Sistema.Instance;

            int exit = 0;

            while (exit == 0)
            {
                try
                {
                    Console.WriteLine("##### ADMIN MENU #####");

                    Console.WriteLine("1 - Crear Articulos");
                    Console.WriteLine("2 - Crear Publicaciones");
                    Console.WriteLine("3 - Validar Subastas activas");
                    Console.WriteLine("4 - Cancelar Publicaciones");
                    Console.WriteLine("0 - Salir");

                    Console.WriteLine("######################");

                    Console.WriteLine("Seleccione una opción: ");
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 0:
                            exit = 1;
                            break;
                        case 1:

                            try
                            {
                                Console.WriteLine("##### ARTICULOS #####");

                                Console.WriteLine("Articulos ya creados: ");

                                foreach (Articulo a in system.Articulos)
                                {   
                                    Console.WriteLine(a.ID + " - " + a.Nombre + " - " + a.Categoria + " - $" + a.Precio);
                                }

                                Console.WriteLine("#####################");

                                Console.WriteLine("Presione cualquier tecla para agregar un nuevo articulo");
                                Console.ReadKey();

                                Console.WriteLine("Ingrese el nombre del articulo: ");
                                string nombre = Console.ReadLine();
                                
                                Console.WriteLine("Ingrese la categoria del articulo: ");
                                string categoria = Console.ReadLine();

                                Console.WriteLine("Ingrese el precio del articulo: ");
                                int precio = int.Parse(Console.ReadLine());

                                userLogued.CrearArticulos(nombre, categoria, precio);

                                Console.WriteLine("El articulo fue ingresado con éxito.");
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        case 2:

                            try
                            {
                                Console.WriteLine("##### PUBLICACIONES #####");

                                Console.WriteLine("Publicaciones ya creadas");

                                foreach (Publicacion p in system.Publicaciones)
                                {
                                    if (p.Estado == Estado.Abierta)
                                    {
                                        Console.WriteLine(p.ID + " - " + p.Nombre + " - " + p.Estado);
                                    }
                                }

                                Console.WriteLine("#########################");

                                Console.WriteLine("Presione cualquier tecla para agregar un nuevo articulo");
                                Console.ReadKey();

                                Console.WriteLine("Ingrese el nombre de la publicacion: ");
                                string nombre = Console.ReadLine();

                                Console.WriteLine("Ingrese los articulos que desea agregar: ");

                                Console.WriteLine("Articulos existentes: ");

                                foreach (Articulo a in system.Articulos)
                                {
                                    Console.WriteLine(a.ID + " - " + a.Nombre + " - " + a.Categoria + " - $" + a.Precio);
                                }

                                string finish = "";
                                List<Articulo> articulosPublicacion = new List<Articulo>();

                                while (finish != "00")
                                {
                                    Console.WriteLine("Ingrese el ID del articulo que desea agregar (Ingrese 00 para salir): ");
                                    string idArticulo = Console.ReadLine();

                                    if (idArticulo != "00")
                                    {
                                        Articulo selectedArticulo = system.ObtenerArticulo(int.Parse(idArticulo));

                                        if (articulosPublicacion.Contains(selectedArticulo))
                                        {
                                            Console.WriteLine("El articulo ya fue agregado a la lista.");
                                        }
                                        else
                                        {
                                            articulosPublicacion.Add(selectedArticulo);
                                        }
                                    }
                                    else
                                    {
                                        finish = "00";
                                    }
                                }

                                Console.WriteLine("Ingrese el tipo de publicacion que desea realizar: ");
                                Console.WriteLine("1 - Venta");
                                Console.WriteLine("2 - Subasta");

                                string tipoPublicacion = "";
                                finish = "";

                                while (finish != "00")
                                {
                                    int tipoElegido = int.Parse(Console.ReadLine());
                                    

                                    switch (tipoElegido)
                                    {
                                        case 1:
                                            tipoPublicacion = "Venta";
                                            finish = "00";
                                            break;
                                        case 2:
                                            tipoPublicacion = "Subasta";
                                            finish = "00";
                                            break;
                                        default:
                                            Console.WriteLine("No a ingresado una opción valida.");
                                            break;
                                    }
                                }

                                userLogued.CrearPublicaciones(nombre, articulosPublicacion, tipoPublicacion);

                                Console.WriteLine("El articulo fue ingresado con éxito.");
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        case 3:

                            try
                            {
                                Console.WriteLine("##### SUBASTAS #####");

                                Console.WriteLine("Subastas activas:");

                                foreach (Publicacion s in system.Publicaciones)
                                {
                                    if (s is Subasta && s.Estado == Estado.Abierta)
                                    {
                                        Subasta su = s as Subasta;

                                        Console.WriteLine(s.ID + " - " + s.Nombre);
                                    }
                                }

                                Console.WriteLine("#####################");

                                Console.WriteLine("Ingrese el ID de una subasta para revisar sus ofertas: ");
                                int eleccion = int.Parse(Console.ReadLine());

                                Subasta selectedSubasta = system.ObtenerSubasta(eleccion);

                                Console.Clear();
                                Console.WriteLine("##### OFERTAS #####");

                                foreach (Oferta o in selectedSubasta.Ofertas)
                                {

                                    Console.WriteLine(o.ID + " - " + o.Monto + " ofertado por: " + o.Cliente.Nombre);

                                }

                                Console.WriteLine("###################");

                                Console.WriteLine("Ingrese 1 para finalizar la subasta o ingrese 0 para cancelar: ");
                                int opcionElegida = int.Parse(Console.ReadLine());

                                if (opcionElegida == 1)
                                {
                                    userLogued.ValidarSubasta(selectedSubasta);

                                    Console.WriteLine("La subasta fue finalizada con éxito, el ganador fue: " + selectedSubasta.Cliente.Nombre); //Consultar porque a esta parte accede aunque vaya a la excepcion
                                    Console.ReadKey();
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        case 4:

                            try
                            {
                                Console.WriteLine("##### CANCELAR PUBLICACION #####");

                                Console.WriteLine("Publicaciones activas: ");

                                foreach (Publicacion p in system.Publicaciones)
                                {
                                    if (p.Estado == Estado.Abierta)

                                    {
                                        Console.WriteLine(p.ID + " - " + p.Nombre);
                                    }
                                }

                                Console.WriteLine("################################");

                                Console.WriteLine("Ingrese el ID de la publicación que quieres cancelar: ");
                                int eleccion = int.Parse(Console.ReadLine());

                                foreach (Publicacion p in system.Publicaciones)
                                {
                                    if (p.ID == eleccion)
                                    {
                                        userLogued.CancelarPublicacion(p);
                                        break;
                                    }
                                }

                                Console.WriteLine("La publicación fue cancelada con éxito."); // Consultar porque continua
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }

                            break;
                        default:
                            Console.WriteLine("La opción ingresada no es valida, por favor vuelva a intentarlo");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        private static void EntregaMenu()
        {
            Sistema system = Sistema.Instance;

            int exit = 0;

            while (exit == 0)
            {
                try
                {
                    Console.WriteLine("##### MENU #####");

                    Console.WriteLine("1 - Listado Clientes");
                    Console.WriteLine("2 - Listar Articulos por categoria");
                    Console.WriteLine("3 - Alta de Articulo");
                    Console.WriteLine("4 - Listar Publicaciones por fecha");
                    Console.WriteLine("0 - Salir");

                    Console.WriteLine("################");

                    Console.WriteLine("Seleccione una opción: ");
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 0:
                            exit = 1;
                            break;
                        case 1:

                            try
                            {
                                Console.WriteLine("##### LISTADO CLIENTES #####");

                                int count = 0;

                                foreach (Usuario c in system.Usuarios)
                                {
                                    if (c is Cliente)
                                    {
                                        count ++;
                                        Console.WriteLine(c.ID + " - " + c.Nombre + " " + c.Apellido + " - " + c.Email);
                                    }
                                }

                                if (count < 0)
                                {
                                    Console.WriteLine("No existen clientes en el sistema.");
                                }

                                Console.WriteLine("############################");

                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();
                            }

                            break;
                        case 2:

                            try
                            {
                                
                                Console.WriteLine("Ingrese la categoria por la que desea buscar");
                                string categoria = Console.ReadLine();

                                List<Articulo> articulos = system.ObtenerArticulosPorCategoria(categoria);
                                
                                Console.WriteLine("##### ARTICULOS POR CATEGORIA #####");

                                foreach(Articulo a in articulos)
                                {
                                    Console.WriteLine(a.ID + " - " + a.Nombre + " $" + a.Precio);
                                }

                                Console.WriteLine("###################################");

                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();
                            }

                            break;
                        case 3:

                            try
                            {
                                int cancel = 0;

                                while (cancel == 0)
                                {
                                    Console.WriteLine("##### CREAR ARTICULO #####");

                                    Console.WriteLine("Ingrese el nombre del articulo: ");
                                    string nombre = Console.ReadLine();

                                    Console.WriteLine("Ingrese la categoria del articulo: ");
                                    string categoria = Console.ReadLine();

                                    Console.WriteLine("Ingrese el precio del articulo: ");
                                    int precio = int.Parse(Console.ReadLine());

                                    Console.WriteLine("#####################");

                                    Console.WriteLine("Los datos ingresados son: " + nombre + " - " + categoria + " - $" + precio);
                                    Console.WriteLine("Presione 1 si desea cancelar la operacion o presione 2 para continuar. Con cualquier otro digito puede volver a ingresar los datos.");

                                    int opcionElegida = int.Parse(Console.ReadLine());

                                    switch(opcionElegida)
                                    {
                                        case 1: cancel = 1; break;
                                        case 2:
                                            if (precio <= 0)
                                            {
                                                Console.WriteLine("El precio debe ser mayor a 0.");
                                            }
                                            else
                                            {
                                                system.AgregarArticulo(nombre, categoria, precio);
                                                cancel = 2; // Le asigno el valor 2 a la variable para salir del while y diferenciarlo de lo cancelado
                                            }
                                            
                                            break;
                                        default: break;
                                    }
                                }

                                if (cancel != 1)
                                {
                                    Console.WriteLine("El articulo fue ingresado con éxito.");
                                }
                                
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();
                            }

                            break;
                        case 4:

                            try
                            {

                                Console.WriteLine("Ingrese la fecha de inicio (01/01/0001): ");
                                DateTime fechaInicio = DateTime.Parse(Console.ReadLine() + " 00:00:00");

                                Console.WriteLine("Ingrese la fecha de fin (31/12/9999): ");
                                DateTime fechaFin = DateTime.Parse(Console.ReadLine() + " 23:59:59");

                                if (fechaFin >= fechaInicio)
                                {
                                    List<Publicacion> publicaciones = system.ObtenerPublicacionesEntreFechas(fechaInicio, fechaFin);

                                    Console.WriteLine("##### PUBLICACIONES ENTRE " + fechaInicio + " y " + fechaFin + " #####");

                                    foreach (Publicacion p in publicaciones)
                                    {
                                        Console.WriteLine(p.ID + " - " + p.Nombre + " - " + p.Estado + " publicado el: " + p.FechaPublicacion);
                                    }
                                } 
                                else
                                {
                                    Console.WriteLine("La fecha de inicio no puede ser posterior a la fecha de fin.");
                                }

                                Console.WriteLine("#########################################################################");

                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Presione cualquier tecla para salir");
                                Console.ReadKey();
                            }

                            break;
                        default:
                            Console.WriteLine("La opción ingresada no es valida, por favor vuelva a intentarlo");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }
    }
}
