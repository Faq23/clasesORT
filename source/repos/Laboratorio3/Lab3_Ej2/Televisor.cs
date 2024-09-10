using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3_Ej2
{
    public class Televisor
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public Tamano Tamano { get; set; }
        public bool IsSmart { get; set; }
        public bool Status { get; set; }
        public int Volume { get; set; }
        
        public Televisor() 
        {
            ID = LastID;
            LastID++;
        }

        public Televisor(Marca marca, string modelo, Tamano tamano, bool isSmart)
        {
            ID = LastID;
            LastID++;
            Marca = marca;
            Modelo = modelo;
            Tamano = tamano;
            IsSmart = isSmart;
            // Valores predefinidos al crear un Televisor
            Status = false;
            Volume = 10;
            Validacion();
        }

        public void Validacion()
        {
            ValidarMarca();
            ValidarModelo();
            ValidarTamano();
        }

        public void ValidarMarca()
        {
            if (Marca == null)
            {
                throw new Exception("No ha ingresado una Marca");
            }
        }
        public void ValidarModelo()
        {
            if (Modelo == "")
            {
                throw new Exception("No ha ingresado un Modelo");
            }
        }

        public void ValidarTamano()
        {
            if (Tamano <= 0)
            {
                throw new Exception("No ha ingresado un Tamaño valido");
            }
        }
    }
}
