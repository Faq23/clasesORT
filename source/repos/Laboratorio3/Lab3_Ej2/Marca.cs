using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej2
{
    public class Marca
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public Pais PaisOrigen { get; set; }
        
        public Marca()
        {
            ID = LastID;
            LastID++;
        }

        public Marca(string nombre, Pais paisOrigen)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            PaisOrigen = paisOrigen;
            Validacion();
        }

        public void Validacion()
        {
            ValidarPaisOrigen();
            ValidarNombre();
        }

        public void ValidarNombre()
        {
            if (Nombre == "")
            {
                throw new Exception("No ha ingresado un Nombre");
            }
        }
        public void ValidarPaisOrigen()
        {
            if (PaisOrigen == null)
            {
                throw new Exception("No ha ingresado un Pais");
            }
        }
    }
}
