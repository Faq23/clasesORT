using System.Numerics;

namespace Lab1_Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese 3 numeros: \n");

            int firstN = int.Parse(Console.ReadLine());
            int seconN = int.Parse(Console.ReadLine());
            int thirdN = int.Parse(Console.ReadLine());

            bool foundMul = false;

            for (int i = firstN; i <= seconN; i++)
            {
                if (i % thirdN == 0)
                {
                    Console.WriteLine($"El numero { i } es multiplo de { thirdN }");
                    foundMul = true;
                }
            }

            if (!foundMul)
            {
                Console.WriteLine($"No se han encontrados multiplos de { thirdN } entre el { firstN } y el { seconN }");
            }

            Console.ReadKey();

        }
    }
}
