using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Unid4_Lab4_Ej1
{
    class ContactosMysqlConDataAdapter : Contactos
    {
        protected string connectionString
        {
            get
            {
                return "server=localhost;database=net;uid=root;pwd=root;";

            }
        }
        protected MySqlDataAdapter adapter;
        public ContactosMysqlConDataAdapter(): base()
        {
            this.adapter.InsertCommand = new MySqlCommand(
                "insert into contactos values(@id,@nombre,@apellido,@email,@telefono)");
            this.adapter.InsertCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            this.adapter.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            this.adapter.InsertCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            this.adapter.InsertCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            this.adapter.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            this.adapter.UpdateCommand = new MySqlCommand(
                "update contactos set nombre=@nombre, apellido=@apellido, email=@email,telefono=@telefono " +
                " where id=@id");
            this.adapter.UpdateCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            this.adapter.UpdateCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            this.adapter.UpdateCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            this.adapter.UpdateCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            this.adapter.UpdateCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            this.adapter.DeleteCommand = new MySqlCommand("delete from contactos where id=@id");
            this.adapter.DeleteCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
        }
        public override DataTable getTabla()
        {
            this.adapter = new MySqlDataAdapter("select * from contactos", this.connectionString);
            DataTable contactos = new DataTable();
            this.adapter.Fill(contactos);
            return contactos;
        }
        public override void aplicaCambios()
        {
            using (MySqlConnection Conn = new MySqlConnection(this.connectionString))
            {
                this.adapter.InsertCommand.Connection = Conn;
                this.adapter.UpdateCommand.Connection = Conn;
                this.adapter.DeleteCommand.Connection = Conn;
                this.adapter.Update(this.misContactos);
            }
        }


    }
}
