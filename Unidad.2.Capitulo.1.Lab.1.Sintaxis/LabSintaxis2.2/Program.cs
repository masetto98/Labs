using System;

namespace LabSintaxis2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introducir texto");
            string inputTexto;        
            inputTexto = Console.ReadLine();
            if (inputTexto != "")
            {
                Console.WriteLine("Menu de opciones" + "\n Ingrese alguna de las siguientes opciones" + "\n 1. Mayuscula" + "\n 2. Minuscula" + "\n 3. Longitud");
                ConsoleKeyInfo opcion = Console.ReadKey();
                switch (opcion.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Conversión:"+ inputTexto.ToUpper());
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Conversión:"+ inputTexto.ToLower());
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Conversión:"+ inputTexto.Length);
                        break;
                    default:
                        Console.WriteLine("La opción ingresada es incorrecta");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Texto vacio");

            }
        }
    }
}
