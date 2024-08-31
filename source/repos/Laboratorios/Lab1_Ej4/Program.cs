namespace Lab1_Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int randomNumber = r.Next(1,10001);

            bool foundNum = false;

            Console.WriteLine("Intente adivinar el número generado: \n");

            int num = int.Parse(Console.ReadLine());

            while (!foundNum)
            {
                if (num != randomNumber)
                {
                    if (num > randomNumber)
                    {
                        Console.WriteLine("Menos - \n Ingrese otro numero:");
                    } else
                    {
                        Console.WriteLine("Mas + \n Ingrese otro numero:");
                    }

                    
                    num = int.Parse(Console.ReadLine());
                } else
                {
                    Console.WriteLine("Correcto!");
                    foundNum = true;
                }
            }

            Console.ReadKey();
        }
    }
}
