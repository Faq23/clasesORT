namespace Lab1_Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool foundN = false;
            
            Console.WriteLine("Ingrese 3 numeros: \n");

            int firstN = int.Parse(Console.ReadLine());
            int seconN = int.Parse(Console.ReadLine());
            int thirdN = int.Parse(Console.ReadLine());

            for (int i = firstN; i <= seconN && !foundN; i++)
            {
                if (i == thirdN)
                {
                    Console.WriteLine("El tercer numero esta incluido entre los dos primeros");
                    foundN = true;
                }
            }

            Console.ReadKey();
        }
    }
}
