using System;

namespace LabSintaxis2
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
                if (opcion.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("Longitud del texto ingresado:" + inputTexto.Length);
                }
                else
                {
                    if (opcion.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine("Conversión:" + inputTexto.ToUpper());
                    }
                    else
                    {
                        if (opcion.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine("Conversion:" + inputTexto.ToLower());
                        }
                        else
                        {
                            Console.WriteLine("Opcion incorrecta");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No se ha ingresado texto");

            }
        }
    }
}
