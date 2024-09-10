using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej2
{
    public class Pais
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        Pais() 
        {
            ID = LastID;
            LastID++;
        }

        public Pais(string nombre, string codigo)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Codigo = codigo;
            Validacion();
        }

        public void Validacion()
        {
            ValidarCodigo();
            ValidarNombre();
        }

        public void ValidarNombre()
        {
            if (Nombre == "")
            {
                throw new Exception("No ha ingresado un Nombre");
            }
        }
        public void ValidarCodigo()
        {
            if (Nombre == "")
            {
                throw new Exception("No ha ingresado un Codigo");
            }
        }
    }
}
