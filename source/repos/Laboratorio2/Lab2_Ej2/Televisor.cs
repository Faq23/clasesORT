using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej2
{
    internal class Televisor
    {
        public int ID { get; }
        public static int LastID { get; set; } = 0;
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Pulgadas { get; set; }
        public bool IsSmart { get; set; }
        public int Volume { get; set; }
        public bool Status { get; set; }

        public Televisor() { }
        public Televisor(string marca, string modelo, double pulgadas, bool isSmart, int volume, bool status)
        {
            ID = LastID;
            LastID++;
            Marca = marca;
            Modelo = modelo;
            Pulgadas = pulgadas;
            IsSmart = isSmart;
            Volume = volume;
            Status = status;
        }

        public string CambiarStatus()
        {
            string message = "";

            if (IsSmart)
            {
                message = "El televisor fue apagado";
                IsSmart = false;
            } else
            {
                message = "El televisor fue encendido";
                IsSmart = true;
            }

            return message;
        }

        public string ObtenerStatus()
        {
            string message = "";

            if (IsSmart)
            {
                message = "El televisor se encuentra encendido";
            } else
            {
                message = "El televisor se encuentra apagado";
            }

            return message;
        }

        public string AlterarVolumen(int vol)
        {
            Volume = Volume + vol;

            return $"Se cambio el volumen del televisor a {Volume}";
        }
    }
}
