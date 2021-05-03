using System;

namespace LabSintaxis4._6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] roman1 = { "M", "MM", "MMM" };
            string[] roman2 = { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] roman3 = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] roman4 = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            int numint;
            Console.WriteLine("Ingresar un numero entero");
            numint = int.Parse(Console.ReadLine());
            Console.WriteLine("En numero romano es:");
            if(numint > 999)
            {
                int mil = numint / 1000;
                Console.Write(roman1[mil-1]);
                if(numint % 1000 != 0)
                {
                    int centena = (numint % 1000) / 100;
                    Console.Write(roman2[centena - 1]);
                    if((numint%1000)%100 != 0)
                    {
                        int decena = (((numint % 1000) % 100) / 10);
                        Console.Write(roman3[decena - 1]);
                        if ((((numint%1000)%100)%10) != 0)
                        {
                            int unid = (((numint % 1000) % 100) % 10);
                            Console.Write(roman4[unid - 1]);
                        }
                    }
                }
            }
            else 
            {
                if (numint>99)
                {
                    int centena = (numint / 100);
                    Console.Write(roman2[centena - 1]);
                    if (numint % 100 != 0)
                    {
                        int decena = (((numint % 1000) % 100) / 10);
                        Console.Write(roman3[decena - 1]);
                        if ((numint % 100) % 10 != 0)
                        {
                            int unid = (((numint % 1000) % 100) % 10);
                            Console.Write(roman4[unid - 1]);
                        }
                    }
                }
                else
                {
                    if (numint > 9)
                    {
                        int decena = (numint / 10);
                        Console.Write(roman3[decena - 1]);
                        if (numint % 10 != 0)
                        {
                            int unid = (numint % 10);
                            Console.Write(roman4[unid - 1]);
                        }
                    }
                    else
                    {
                        Console.Write(roman4[numint- 1]);
                    }
                }
            }
        }
    }
}
