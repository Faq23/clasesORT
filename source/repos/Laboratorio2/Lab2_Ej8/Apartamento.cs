using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej8
{
    internal class Apartamento
    {
        public int Numero { get; set; }
        public int CantidadCuartos { get; set; }
        public int Piso { get; set; }
        public Vistas Vista { get; set; }
        public static int ValorBase { get; set; } = 1000; // Le dejo 1000 predefinido

        public enum Vistas
        {
            calle,
            interior
        }

        public Apartamento()
        {
        }

        public Apartamento(int numero, int cantidadCuartos, int piso, Vistas vista)
        {
            Numero = numero;
            CantidadCuartos = cantidadCuartos;
            Piso = piso;
            Vista = vista;
        }

        public double CalcularValor()
        {
            double valorApartamento = ValorBase;

            if (CantidadCuartos >= 2)
            {
                valorApartamento = valorApartamento + ( ValorBase * 0.20 );
            }

            if (Piso >= 6)
            {
                valorApartamento = valorApartamento + ( ValorBase * 0.05 );
            }

            return valorApartamento;
        }

        public override string ToString()
        {
            return $"El apartamento numero { Numero } con { CantidadCuartos } habitaciones, ubicado en el piso { Piso } tiene un valor de { CalcularValor() } dolares";
        }
    }
}
