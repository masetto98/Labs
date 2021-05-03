using System;
using Clases;
namespace LabClasePersona
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona per1 = new Persona("Juan", "Perez", 15, "41085815");
            per1.GetFullName();
            per1.GetAge();
        }
    }
}
