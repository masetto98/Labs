using System;

namespace LabSintaxis4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            Console.WriteLine("Ingresar numero 1");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar numero 2");
            num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("El resultado de la suma de:" + num1 + " " + "y" + " " + num2 +" " + "es" +" "+ (num1+num2));
        }
    }
}
