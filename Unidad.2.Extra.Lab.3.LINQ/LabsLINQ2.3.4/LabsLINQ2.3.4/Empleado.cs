using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLINQ2._3._4
{
    class Empleado
    {
        private int _idEmpleado;
        private string _nomEmpleado;
        private decimal _sueldoEmp;
        public int IdEmp
        {
            get
            {
                return _idEmpleado;
            }
            set
            {
                _idEmpleado = value;
            }
        }
        public string NombreEmp
        {
            get
            {
                return _nomEmpleado;
            }
            set
            {
                _nomEmpleado = value;
            }
        }
        public decimal SueldoEmp
        {
            get
            {
                return _sueldoEmp;
            }
            set
            {
                _sueldoEmp = value;
            }
        }
        public void Menu(List<Empleado> emp)
        {
            bool ok = true;
            int op = 0;
            while (ok)
            {
                Console.WriteLine("Menu de opciones");
                Console.WriteLine("1. Ingrese un nuevo empleado");
                Console.WriteLine("2. Mostrar empleados");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        emp.Add(AltaEmp());
                        break;
                    case 2:
                        MostrarEmpleado(emp);
                        break;
                }
            }
        }
        public Empleado AltaEmp()
        {
            
            Empleado emp = new Empleado();
            Console.WriteLine("Ingresar nombre para el nuevo empleado");
            emp.NombreEmp = Console.ReadLine();
            Console.WriteLine("Ingresar ID para el nuevo empleado");
            emp.IdEmp = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar Sueldo para el nuevo empleado");
            emp.SueldoEmp = decimal.Parse(Console.ReadLine());
            return emp;
        }
        public void MostrarEmpleado(List<Empleado> empleados)
        {
            var misEmpleadosasc = from e in empleados orderby e.SueldoEmp ascending select e;
            var misEmpleadosdesc = from e in empleados orderby e.SueldoEmp descending select e;
            foreach (var e in misEmpleadosasc)
            {
                Console.WriteLine("ID: "+e.IdEmp+ " Nombre: "+ e.NombreEmp +" Sueldo: "+e.SueldoEmp);
            }
            foreach(var e in misEmpleadosdesc)
            {
                Console.WriteLine("ID: " + e.IdEmp + " Nombre: " + e.NombreEmp + " Sueldo: " + e.SueldoEmp);
            }
        }
    }
}
