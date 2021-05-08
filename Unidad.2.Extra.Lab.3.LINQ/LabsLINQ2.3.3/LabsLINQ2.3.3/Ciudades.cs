using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLINQ2._3._3
{
    class Ciudades
    {
        private string _nombre;
        private int _codpostal;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public int CodPostal
        {
            get
            {
                return _codpostal;
            }
            set
            {
                _codpostal = value;
            }
        }
    
    }
    
}
