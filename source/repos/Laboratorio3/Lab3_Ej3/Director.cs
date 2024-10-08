using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej3
{
    public class Director
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Pais Pais { get; set; }

        public Director()
        {
            ID = LastID;
            LastID++;
        }
        public Director(string nombre, string apellido, Pais pais) 
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Apellido = apellido;
            Pais = pais;
            Validacion();
        }

        private void Validacion()
        {
            ValidarNombre();
            ValidarApellido();
        }

        private void ValidarNombre() 
        { 
            if (Nombre == "")
            {
                throw new Exception("No ha ingresado un Nombre correcto");
            }
        }
        private void ValidarApellido()
        {
            if (Apellido == "")
            {
                throw new Exception("No ha ingresado un Apellido correcto");
            }
        }
    }
}
