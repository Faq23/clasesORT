using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej7
{
    public class Producto
    {
        public int ID { get; set; }
        public static int LastID { get; set; }
        public string Nombre { get; set; }
        public Activos Activo { get; set; }
        public int Concentracion { get; set; }
        public DateTime FechaFabricacion { get; set; }

        public Producto() 
        {
        }
        public Producto(string nombre, Activos activo, int concentracion, DateTime fechaFabricacion)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Activo = activo;
            Concentracion = concentracion;
            FechaFabricacion = fechaFabricacion;
        }

        public enum Activos
        {
            ibuprofeno,
            paracetamol
        }

        public DateTime FechaVencimiento()
        {
            DateTime FechaVencimiento = FechaFabricacion.AddYears(2).AddMonths(6);
            return FechaVencimiento;
        }

        public override string ToString()
        {
            return $"El producto { Nombre } de activo { Activo } de { Concentracion } mg tiene como fecha de Fabricacion { FechaFabricacion }";
        }
    }
}
