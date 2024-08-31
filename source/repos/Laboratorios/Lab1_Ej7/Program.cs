using System.ComponentModel;
using System.Timers;

namespace Lab1_Ej7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = -1;
            int firstN = 0;
            int seconN = 0;

            Console.WriteLine("######### Calculadora #########");

            while (option != 0)
            {
                Console.WriteLine("1 - Suma");
                Console.WriteLine("2 - Resta");
                Console.WriteLine("3 - Multiplicacion");
                Console.WriteLine("4 - Division");
                Console.WriteLine("0 - Salir");

                Console.WriteLine("Ingrese una opcion: ");
                option = int.Parse(Console.ReadLine());

                if (option != 0)
                {
                    Console.WriteLine("Ingrese dos numeros para realizar la operacion: \n");
                    firstN = int.Parse(Console.ReadLine());
                    seconN = int.Parse(Console.ReadLine());
                }

                double res = 0;

                switch(option)
                {
                    case 1:
                        res = Suma(firstN, seconN);
                        Console.WriteLine($"El resultado de { firstN } + { seconN } es {res}");
                        break;
                    case 2:
                        res = Resta(firstN, seconN);
                        Console.WriteLine($"El resultado de {firstN} - {seconN} es {res}");
                        break;
                    case 3:
                        res = Multiplicacion(firstN, seconN);
                        Console.WriteLine($"El resultado de {firstN} * {seconN} es {res}");
                        break;
                    case 4:
                        res = Division(firstN, seconN);
                        Console.WriteLine($"El resultado de {firstN} / {seconN} es {res}");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

                Console.Clear();
            }

            Console.ReadKey();
        }

        static int Suma(int n1, int n2)
        {
            return n1 + n2;
        }

        static int Resta(int n1, int n2)
        {
            return n1 - n2;
        }

        static int Multiplicacion(int n1, int n2)
        {
            return n1 * n2;
        }

        static double Division(int n1, int n2)
        {
            double result = 0;

            if (n2 != 0)
            {
                result = n1 / n2;
            }

            return result;
        }
    }
}
