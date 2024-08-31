namespace Laboratorio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool foundMul = false;

            Console.WriteLine("Ingrese dos números: \n");
            
            int firstN = int.Parse(Console.ReadLine());
            int seconN = int.Parse(Console.ReadLine());

            int cont = firstN;

            while (!foundMul && cont <= seconN)
            {
                if (cont % 33 == 0)
                {
                    Console.WriteLine($"El numero {cont - 1} es el primer multiplo de 33");
                    foundMul = true;
                }

                cont++;
            }


            if (!foundMul)
            {
                Console.WriteLine("No existe numero multiplo de 33");
            }

            Console.ReadKey();

            /*
             Otro metodo:

            for (int i = firstN; i <= seconN && !foundMul; i++)
            {
                if (i % 33 == 0) 
                {
                    Console.WriteLine(i);
                    foundMul = true;
                }
            }
             */
        }
    }
}
