using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClases5AdivNum
{
    public class Jugada
    {
        private int _numero;
        private int _cantIntentos;
        private bool _acertado;

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            Numero = rnd.Next(maxNumero);
            CantIntentos = 0;
        }
        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
            }
        }
        public int CantIntentos
        {
            get
            {
                return _cantIntentos;
            }
            set
            {
                _cantIntentos = value;
            }
        }
        public bool Acertado
        {
            get
            {
                return _acertado;
            }
            set
            {
                _acertado = value;
            }
        }

        public void Comparar(int eleccion)
        {
            if(Numero == eleccion)
            {
                Acertado = true;
            }
            else
            {
                Acertado = false;
            }
            CantIntentos += 1;
        }
    }
}
