using System;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            string[] names = new string[cantIteraciones];
            for (int i = 0; i < cantIteraciones; i++)
            {

                Console.Write($"Ingrese valor para la posición {i + 1}: ");
                names[i] = Console.ReadLine();
            }
            for (int i = cantIteraciones-1; i >= 0; i--)
            {
                Console.WriteLine(names[i]);

            }

        }
          
    }
}
