using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej1
{
    public class Mesa
    {
        public int ID { get; }
        public static int ultimoID { get; set; } = 0;
        public double Largo { get; set; }
        public double Ancho { get; set; }
        public double Altura { get; set; }
        public string Material { get; set; }
        public double Precio { get; set; }

        public Mesa()
        {
        }
        public Mesa(double largo, double ancho, double altura, string material, double precio)
        {
            ID = ultimoID;
            ultimoID++;
            Largo = largo;
            Ancho = ancho;
            Altura = altura;
            Material = material;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Estas son las caracteristicas de la mesa:\n Largo: {Largo} mts\n Ancho: {Ancho} mts\n Altura: {Altura}mts \n Material: {Material}\n Precio: ${Precio}";
        }
    }
}
