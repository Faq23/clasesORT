using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo : IValidable
    {
        // Properties
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Precio { get; set; }

        // Constructores
        public Articulo()
        {
            ID = LastID;
            LastID++;
        }

        public Articulo(string nombre, string categoria, int precio)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Validacion();
        }

        // Metodos

        public void Validacion()
        {
            ValidarNombre();
            ValidarCategoria();
            ValidarPrecio();
        }
        private void ValidarNombre()
        {
            string pattern = @"^[\p{L}\d\s'-]+$"; // Admito letras, numeros y solamente el (-) 

            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("No ha ingresado un Nombre");
            } else if(!Regex.IsMatch(Nombre, pattern))
            {
                throw new Exception("No ha ingresado un Nombre válido. El mismo no puede contener caracteres especiales expecto (-)");
            }
        }
        private void ValidarCategoria()
        {
            string pattern = @"^[\p{L}\d\s'-]+$"; // Admito letras, numeros y solamente el (-) 

            if (string.IsNullOrEmpty(Categoria))
            {
                throw new Exception("No ha ingresado una Categoria");
            }
            else if (!Regex.IsMatch(Categoria, pattern))
            {
                throw new Exception("No ha ingresado una Categoria válido. El mismo no puede contener caracteres especiales expecto (-)");
            }
        }
        private void ValidarPrecio()
        {
            if (Precio < 1)
            {
                throw new Exception("El Articulo no puede tener Precio menor a 1");
            }
        }
    }
}