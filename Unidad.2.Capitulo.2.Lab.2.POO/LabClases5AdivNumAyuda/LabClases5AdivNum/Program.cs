using System;

namespace LabClases5AdivNum
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir=false;
            while (salir == false)
            {
                Juego j = new Juego();
                Console.WriteLine("Seleccione una de las siguiente opciones");
                Console.WriteLine("1. Comenzar juego");
                Console.WriteLine("2. Ver record");
                Console.WriteLine("3.Salir");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            j.ComenzarJuego();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            salir = true;
                            break;
                        }
                }
            }
        }
    }
}
