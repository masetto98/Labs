using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClases5AdivNum
{
    public class JugadaConAyuda : Jugada
    {
        public JugadaConAyuda(int max1): base(max1)
        {
        }
        public new void Comparar(int eleccion)
        {
            if (Numero == eleccion)
            {
                Acertado = true;
            }
            else
            {
                Acertado = false;
                int diferencia = Math.Abs(Numero - eleccion);
                if (diferencia > Numero * 0.5)
                {
                    Console.WriteLine("Estás bastante lejos");
                }
                else if (diferencia > Numero * 0.25)
                {
                    Console.WriteLine("Estas lejos");
                }
                else if (diferencia > Numero * 0.1)
                {
                    Console.WriteLine("Estar cerca!");
                }
                else
                {
                    Console.WriteLine("Estas bastante cerca!");
                }
            }
            CantIntentos += 1;
        }
    }
}
