using System;

namespace LabSintaxis4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            while (x < 100)
            {
                if(x % 2 == 0)
                {
                    Console.WriteLine(x);     
                }
                x += 1;
            }
        }
    }
}
