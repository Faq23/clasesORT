using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej1
{
    public class Material
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
    
        public Material() 
        {
            ID = LastID;
            LastID++;
        }

        public Material(string nombre, string paisOrigen)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            PaisOrigen = paisOrigen;
            Validacion();
        }

        private void Validacion()
        {
            ValidarNombre();
            ValidarPaisOrigen();
        }

        private void ValidarPaisOrigen()
        {
            if (PaisOrigen == "")
            {
                throw new Exception("No ha ingresado un País");
            }
        }

        private void ValidarNombre()
        {
            if (Nombre == "")
            {
                throw new Exception("No ha ingresado un Nombre");
            }
        }
    }
}
