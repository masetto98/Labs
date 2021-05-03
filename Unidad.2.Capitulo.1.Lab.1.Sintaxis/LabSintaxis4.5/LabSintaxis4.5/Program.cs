using System;

namespace LabSintaxis4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string mes;
            bool valid = true;
            string[] nMes = new string[] { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
            Console.WriteLine("Ingresar nombre del mes");
            mes = Console.ReadLine();
            valid = Validacion(mes, nMes);
            if (valid == true)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (mes.ToLower() == nMes[i])
                    {
                        Console.WriteLine("El numero del mes ingresado es:" + (i + 1));
                    }
                }
            }
            else
            {
                Console.WriteLine("Nombre de mes incorrecto");
            }

        }
        public static bool Validacion(string mes, string[] nmes)
        {
            string m = mes;
            
            for(int i=0; i < 12; i++)
            {
                if(mes.ToLower() == nmes[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
