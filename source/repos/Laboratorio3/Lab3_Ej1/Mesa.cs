using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej1
{
    public class Mesa
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public int Ancho { get; set; }
        public int Largo { get; set; }
        public int Altura { get; set; }
        public Material Material { get; set; }
        public int Precio { get; set; }

        public Mesa()
        {
            ID = LastID;
            LastID++;
        }

        public Mesa(int ancho, int largo, int altura, Material material, int precio)
        {
            ID = LastID;
            LastID++;
            Ancho = ancho;
            Largo = largo;
            Altura = altura;
            Material = material;
            Precio = precio;
            Validacion();
        }

        private void Validacion()
        {
            ValidarAltura();
            ValidarAncho();
            ValidarPrecio();
            ValidarMaterial();
            ValidarLargo();
        }
        private void ValidarAncho()
        {
            if (Ancho <= 0)
            {
                throw new Exception("La altura no es valida");
            }
        }
        private void ValidarLargo()
        {
            if (Largo <= 0)
            {
                throw new Exception("La altura no es valida");
            }
        }
        private void ValidarAltura()
        {
            if (Altura <= 0)
            {
                throw new Exception("La altura no es valida");
            }
        }
        private void ValidarPrecio()
        {
            if (Precio <= 0)
            {
                throw new Exception("La altura no es valida");
            }
        }

        private void ValidarMaterial()
        {
            if (Material == null)
            {
                throw new Exception("No ha ingresado ningun Material");
            }
        }

        public override string ToString()
        {
            return $"La mesa de { Material.Nombre } tiene unas medidas de { Ancho } x { Largo } x { Altura } y un precio de { Precio }";
        }
    }
}
