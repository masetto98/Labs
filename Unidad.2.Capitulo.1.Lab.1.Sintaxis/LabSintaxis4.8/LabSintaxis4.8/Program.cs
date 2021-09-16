using System;

namespace LabSintaxis4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int intentos = 0;
            string password = "santi123";
            bool ok=false;
            while (ok==false & intentos<4)
            {
                Console.Write("Ingresar clave: ");
                string entrypass = Console.ReadLine();
                intentos += 1;
                if (entrypass == password)
                {
                    Console.WriteLine("Clave correcta!!");
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Clave incorrecta vuelva a intentar");
                }
            }
            if (intentos > 3)
            {
                Console.WriteLine("Se superó el máximo de intentos posible");
                Console.ReadKey();
            }


         
        }
    }
}
