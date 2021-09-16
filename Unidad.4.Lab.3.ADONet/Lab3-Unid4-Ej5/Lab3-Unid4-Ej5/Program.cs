using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab3_Unid4_Ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source = .\\LOCALHOST;Initial Catalog=Northwind;User ID= net;Pwd=net";
            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();

            Console.WriteLine("Listado de empresas:");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + " - " + nombreempresa);
            }
            Console.ReadLine();

        }
    }
}
