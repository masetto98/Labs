using System;

namespace LabSintaxis4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int anio;
            bool bisiesto = false;
            Console.WriteLine("Ingresar un año");
            anio = int.Parse(Console.ReadLine());
            if (anio % 4 == 0)
            {
                if(anio % 100 == 0)
                {
                    if(anio % 400 == 0)
                    {
                        bisiesto = true;
                    }
                }
            
            }
            if (bisiesto)
            {
                Console.WriteLine("Es un año bisiesto");
            }
            else
            {
                Console.WriteLine("No es un año bisiesto");
            }
        }
    }
}
