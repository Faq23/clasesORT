using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Publicacion
    {
        // Properties

        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<Articulo> ListaArticulos { get; set; } = new List<Articulo>();
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaFin { get; set; }

        // Constructores

        public Publicacion() 
        {
            ID = LastID;
            LastID++;
        }

        public Publicacion(string nombre, List<Articulo> listaArticulos)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Estado = Estado.Abierta;
            FechaPublicacion = DateTime.Now;
            ListaArticulos = listaArticulos;
            Validacion();
        }

        // Metodos

        private void Validacion()
        {
            ValidarArticulos();
            ValidarNombre();
        }
        private void ValidarNombre()
        {
            string pattern = @"^[\p{L}\d\s'-]+$"; // Admito letras, numeros y solamente el (-) 

            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("No ha ingresado un Nombre");
            }
            else if (!Regex.IsMatch(Nombre, pattern))
            {
                throw new Exception("No ha ingresado un Nombre válido. El mismo no puede contener caracteres especiales expecto (-)");
            }
        }
        private void ValidarArticulos()
        {
            if (ListaArticulos.Count <= 0) 
            {
                throw new Exception("Para crear una publicación debe ingresar una lista con Articulos");
            }
        }

        public void CancelarPublicacion(Administrador administrador)
        {
            if (Estado == Estado.Abierta)
            {
                Usuario = administrador;
                FechaFin = DateTime.Now;
                Estado = Estado.Cancelada;
            }
            else
            {
                throw new Exception("Solo se pueden cancelar Publicaciones que esten Abiertas actualmente");
            }
        }
    }
}
