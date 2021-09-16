using System;
using System.Collections.Generic;
using System.Linq;
namespace LabsLINQ2._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = true;
            List<int> numeros = new List<int>();
            string sigue;
            while (ok)
            {
                int limite = 0;
                while (limite <= 10)
                {
                    Console.WriteLine("Ingrese diez numeros enteros");
                    numeros.Add(int.Parse(Console.ReadLine()));
                    limite += 1;
                }
                Console.WriteLine("¿Desea agregar más números? s/n");
                sigue = Console.ReadLine();
                if (sigue.ToUpper() == "N")
                {
                    ok = false;
                }
            }
            var numout = from n in numeros where n > 20 select n;
            Console.WriteLine("Lista de numero ingresados mayores a 20");
            foreach (var n in numout)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
