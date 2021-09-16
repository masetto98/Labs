using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClases5AdivNum
{
    class Juego
    {
        private int _record=0;

        public void ComenzarJuego()
        {
            bool seguir = true;
            while(seguir)
            {
                Console.WriteLine("Ingresar numero maximo entre los que se elige el numero al azar");
                int max = int.Parse(Console.ReadLine());
                JugadaConAyuda _juga = new JugadaConAyuda(max);
                bool adivinar = false;
                while(adivinar == false)
                {
                    Console.WriteLine("Ingresar numero para adivinar: ");
                    try
                    {
                        _juga.Comparar(int.Parse(Console.ReadLine()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    adivinar = _juga.Acertado;
                    if (adivinar)
                    {
                        Console.WriteLine("Correcto!!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrecto!!");
                    }
                }
                int ii = _juga.CantIntentos;
                CompararRecord(ii);
                Console.WriteLine("Quiere jugar de nuevo?");
                Console.WriteLine("Si/No");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "Si":
                        seguir = true;
                        break;
                    case "No":
                        seguir = false;
                        break;
                }
            }
        }

        public void CompararRecord(int intentos)
        {
            if (_record == 0 || _record > intentos)
            {
                _record = intentos;
                Console.WriteLine("Nuevo Record!!");
            }
            else
            {
                Console.WriteLine("No se mejoro el record actual :( ");
            }
        }

        private void Continuar()
        {
            throw new System.NotImplementedException();
        }

        private void PreguntarMaximo()
        {
            throw new System.NotImplementedException();
        }

        private void PreguntarNumero()
        {
            throw new System.NotImplementedException();
        }
        public void GetRecord()
        {
            Console.WriteLine("El record actual es de " + _record + " intentos");
        }
    }
}
