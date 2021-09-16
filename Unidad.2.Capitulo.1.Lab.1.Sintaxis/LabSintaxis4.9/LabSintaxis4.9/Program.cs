using System;

namespace LabSintaxis4._9
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Ingresar cantidad de filas: ");
            int cantifil = int.Parse(Console.ReadLine());
            for(int i=1; i <= cantifil; i++)
            {
                for(int x = 0; x < cantifil-i; x++)
                {
                    Console.Write(" ");
                }
                
                for (int esp = 0; esp < (i*2)-1  ;esp++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
