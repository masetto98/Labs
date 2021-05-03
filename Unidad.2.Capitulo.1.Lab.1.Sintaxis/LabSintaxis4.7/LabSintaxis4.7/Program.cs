using System;

namespace LabSintaxis4._7
{
    class Program
    {
        static void Main(string[] args)
        {
            int limite = 200;
            int numprim1 = 0;
            int numprim2 = 0;
            for(int i=2; i < limite; i++)
            {
                bool esPrimo1 = true;
                bool esPrimo2 = true;
                for (int z=2; z < i; z++)
                {
                    if(i % z == 0)
                    {
                        esPrimo1 = false;
                        break;
                    }
                }
                if (esPrimo1)
                {
                    numprim1 = i;
                    numprim2 = numprim1 + 2;
                    for(int n=2; n<numprim2; n++)
                    {
                        if(numprim2%n == 0)
                        {
                            esPrimo2 = false;
                            break;
                        }
                    }
                    if (esPrimo1 & esPrimo2)
                    {
                        Console.WriteLine("Numero primo: " + numprim1 + " Gemelo:" + numprim2);
                    }

                }
            }
        }
    }
}
