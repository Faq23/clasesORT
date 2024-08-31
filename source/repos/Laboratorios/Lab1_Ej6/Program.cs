namespace Lab1_Ej6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = -1;

            Console.WriteLine("Seleccione una opcion: \n");

            while (option != 0)
            {
                Console.WriteLine("1 - Enero");
                Console.WriteLine("2 - Febrero");
                Console.WriteLine("3 - Marzo");
                Console.WriteLine("4 - Abril");
                Console.WriteLine("5 - Mayo");
                Console.WriteLine("6 - Junio");
                Console.WriteLine("7 - Julio");
                Console.WriteLine("8 - Agosto");
                Console.WriteLine("9 - Septiembre");
                Console.WriteLine("10 - Octubre");
                Console.WriteLine("11 - Noviembre");
                Console.WriteLine("12 - Diciembre");
                Console.WriteLine("0 - Salir\n");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Los feriados de Enero son:\n");
                        Console.WriteLine(" 01/01 - Año Nuevo\n 06/01 - Dia de Reyes\n");
                        break;
                    case 2:
                        Console.WriteLine("Los feriados de Febrero son:\n");
                        Console.WriteLine(" 12/02 al 13/02 - Carnaval\n");
                        break;
                    case 3:
                        Console.WriteLine("Los feriados de Marzo son:\n");
                        Console.WriteLine(" 28/03 al 29/03 - Turismo\n");
                        break;
                    case 4:
                        Console.WriteLine("Los feriados de Abril son:\n");
                        Console.WriteLine(" 19/04 - Desembarco de los Treinta y Tres Orientales\n");
                        break;
                    case 5:
                        Console.WriteLine("Los feriados de Mayo son:\n");
                        Console.WriteLine(" 01/05 - Dia de los Trabajadores\n 18/05 - Batalla de Las Piedras\n");
                        break;
                    case 6:
                        Console.WriteLine("Los feriados de Junio son:\n");
                        Console.WriteLine(" 19/06 - Natalicio de Artigas\n");
                        break;
                    case 7:
                        Console.WriteLine("Los feriados de Julio son:\n");
                        Console.WriteLine(" 18/07 - Jura de la Constitucion\n");
                        break;
                    case 8:
                        Console.WriteLine("Los feriados de Agosto son:\n");
                        Console.WriteLine(" 25/08 Declaratoria de la Independencia\n");
                        break;
                    case 9:
                        Console.WriteLine("No hay feriados en Septiembre\n");
                        break;
                    case 10:
                        Console.WriteLine("Los feriados de Octubre son:\n");
                        Console.WriteLine(" 12/10 - Dia de la Raza\n");
                        break;
                    case 11:
                        Console.WriteLine("Los feriados de Noviembre son:\n");
                        Console.WriteLine(" 02/11 - Dia de los Difuntos\n");
                        break;
                    case 12:
                        Console.WriteLine("Los feriados de Diciembre son:\n");
                        Console.WriteLine(" 25/12 - Navidad\n");
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
    }
}
