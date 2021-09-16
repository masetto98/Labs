using System;

namespace Clases
{
    public class A
    {
        private string _NombreInstancia;
        public string NombreInstancia
        {
            get
            {
                return _NombreInstancia;
            }
            set
            {
               _NombreInstancia= value;
            }
        }
        public A()
        {
           NombreInstancia = "Instancia Sin Nombre";
        }
        public A(string nomb)
        {
            NombreInstancia = nomb;
        }
        public void MostrarNombre()
        {
            Console.WriteLine(NombreInstancia);
        }
        public void M1()
        {
            Console.WriteLine("El metodo m1 fue invocado");
        }
        public void M2()
        {
            Console.WriteLine("El metodo m2 fue invocado");
        }
        public void M3()
        {
            Console.WriteLine("El metodo m3 fue invocado");
        }
    }   

}
