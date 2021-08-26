﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab2._01TXT_XML
{
    class ManejadorArchivo
    {
        protected DataTable misContactos;
        public ManejadorArchivo()
        {
            this.misContactos = this.getTabla();
        }
        public virtual DataTable getTabla()
        {
            return new DataTable();
        }
        public virtual void aplicaCambios()
        {

        }
        public void nuevaFila()
        {
            DataRow fila = this.misContactos.NewRow();
            foreach(DataColumn col in this.misContactos.Columns)
            {
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();

            }
            this.misContactos.Rows.Add(fila);
        }
        public void editarFila()
        {
            Console.WriteLine("Ingrese el numero de fila a editar");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = this.misContactos.Rows[nroFila - 1];
            for(int nroCol = 1; nroCol < this.misContactos.Columns.Count; nroCol++)
            {
                DataColumn col = this.misContactos.Columns[nroCol];
                Console.Write("Ingrese{0}:", col.ColumnName);
                fila[col] = Console.ReadLine();

            }
        }
        public void eliminarFila()
        {
            Console.WriteLine("Ingrese el numero de fila a eliminar");
            int fila = int.Parse(Console.ReadLine());
            this.misContactos.Rows[fila - 1].Delete();
        }
    }
}
