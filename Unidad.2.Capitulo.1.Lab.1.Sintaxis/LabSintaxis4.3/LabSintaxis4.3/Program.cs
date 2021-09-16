using System;

namespace LabSintaxis4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 1;
            int x;
            int limite = 1000;
            while (num2 + num1 <= limite)
            {
                x = num1;
                num1 = num2;
                num2 = x + num1;
                Console.WriteLine(num2);
            }
        }
    }
}
