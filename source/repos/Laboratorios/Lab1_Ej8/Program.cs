namespace Lab1_Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = -1;
            int pesosValue = 0;

            Console.WriteLine("######### Calculadora #########");

            while (option != 0)
            {
                Console.WriteLine("1 - Dolares");
                Console.WriteLine("2 - Euros");
                Console.WriteLine("3 - Pesos Argentinos");
                Console.WriteLine("0 - Salir");

                Console.WriteLine("Ingrese una opcion: ");
                option = int.Parse(Console.ReadLine());

                if (option != 0)
                {
                    Console.WriteLine("Ingrese el monto a convertir en pesos uruguayos: \n");
                    pesosValue = int.Parse(Console.ReadLine());
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine($"Equivale a {pesosValue / 41} dolares");
                        break;
                    case 2:
                        Console.WriteLine($"Equivale a {pesosValue / 47} euros");
                        break;
                    case 3:
                        Console.WriteLine($"Equivale a {pesosValue / 0.2} pesos argentinos");
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
