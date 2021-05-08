using System;
using System.Collections.Generic;
using System.Linq;

namespace LabsLINQ_2._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] provincias;
            // provincias = new string[23] { "Jujuy", "Salta", "Formosa", "Chaco", "Corrientes", "Misiones", "Catamarca", "Tucuman", "Santiago del Estero", "Santa Fe", "Entre Rios", "La Rioja", "Cordoba", "San Juan", "San Luis", "Mendoza", "La Pampa", "Buenos Aires", "Neuquen", "Rio Negro", "Chubut", "Santa Cruz", "Tierra del Fuego" };
            var provincias = new List<string> { "Jujuy", "Salta", "Formosa", "Chaco", "Corrientes", "Misiones", "Catamarca", "Tucuman", "Santiago del Estero", "Santa Fe", "Entre Rios", "La Rioja", "Cordoba", "San Juan", "San Luis", "Mendoza", "La Pampa", "Buenos Aires", "Neuquen", "Rio Negro", "Chubut", "Santa Cruz", "Tierra del Fuego" };
            var misProv = from p in provincias where (p.StartsWith("S") || p.StartsWith("T")) select p;
            foreach (var p in misProv)
            {
                Console.WriteLine(p);
            }
        }
    }
}
