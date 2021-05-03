using System;

namespace Clases
{
    public class Persona
    {
        private string _nombreP;
        private string _apeP;
        private int _edadP;
        private string _dniP;
        public Persona(string n, string ape, int edad, string dni)
        {
            NombreP = n;
            ApeP = ape;
            EdadP = edad;
            DniP = dni;
            Console.WriteLine("Instancia persona creada");

        }
        public string NombreP
        {
            get
            {
                return _nombreP;
            }
            set
            {
                _nombreP = value;
            }
        }
        public string ApeP
        {
            get
            {
                return _apeP;
            }
            set
            {
                _apeP = value;
            }
        }
        public int EdadP
        {
            get
            {
                return _edadP;
            }
            set
            {
                _edadP = value;
            }
        }
        public string DniP
        {
            get
            {
                return _dniP;
            }
            set
            {
                _dniP = value;
            }
        }
        ~Persona()
        {
            Console.WriteLine("Eliminado");
        }
        public void GetFullName()
        {
            Console.WriteLine(NombreP +" "+ ApeP);
        }
        public void GetAge()
        {
            Console.WriteLine(EdadP);
        }
    }
}
