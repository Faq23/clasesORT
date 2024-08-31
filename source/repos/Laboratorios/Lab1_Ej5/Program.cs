namespace Lab1_Ej5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = -1;

            Console.WriteLine("Seleccione una opcion: \n");

            while (option != 0)
            {
                Console.WriteLine(("1 - Usuarios\n"));
                Console.WriteLine(("2 - Administradores\n"));
                Console.WriteLine(("0 - Salir\n"));

                option = int.Parse(Console.ReadLine());

                if ( option == 1 )
                {
                    Console.WriteLine("Bienvenido a Usuarios\n");
                } else if (option == 2)
                {
                    Console.WriteLine("Bienvenido a Administradores\n");
                }
            }

            Console.ReadKey();
        }
    }
}
