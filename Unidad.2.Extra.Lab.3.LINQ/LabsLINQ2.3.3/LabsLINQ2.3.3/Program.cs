using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace LabsLINQ2._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ciudades> ciudades = new List<Ciudades>()
            {
                new Ciudades() 
                {
                    Nombre = "Rosario", 
                    CodPostal = 2000
                },
                 new Ciudades()
                 {
                     Nombre = "Córdoba",
                     CodPostal = 5000
                 },
                new Ciudades()
                {
                    Nombre = "Santa Fe",
                    CodPostal = 3000
                },
                new Ciudades() 
                {
                    Nombre = "San Miguel De Tucuman",
                    CodPostal = 4000
                },
                new Ciudades()
                {
                    Nombre = "Firmat",
                    CodPostal = 2630
                },
                new Ciudades()
                {
                    Nombre = "Mar del Plata",
                    CodPostal = 4000
                },
                new Ciudades()
                {
                    Nombre = "Mendoza",
                    CodPostal = 5500
                },
                new Ciudades()
                {
                    Nombre = "Ushuaia",
                    CodPostal = 9410
                },
                new Ciudades()
                {
                    Nombre = "San Carlos de Bariloche",
                    CodPostal = 8400
                },
                new Ciudades()
                {
                    Nombre = "Bahia Blanca",
                    CodPostal = 8000
                },
                new Ciudades()
                {
                    Nombre = "San Rafael",
                    CodPostal = 5600
                }
            };
            Console.WriteLine("Ingresar nombre de ciudad que desee");
            string op = Console.ReadLine();
            var listCiudades = from c in ciudades where (c.Nombre.ToLower().StartsWith(op.ToLower()) == true) select c;
            foreach(var c in listCiudades)
            {
                Console.WriteLine("Ciudad ingresada: " + c.Nombre + " Codigo Postal " + c.CodPostal);
            }

        }
    }
}
