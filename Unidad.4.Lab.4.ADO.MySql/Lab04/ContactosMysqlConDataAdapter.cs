using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab04
{
    public class ContactosMysqlConDataAdapter : Contactos
    {
        // IMPORTANTE: Actualiza estos datos con las credenciales de tu servidor MySQL local
        private string connectionString = "server=localhost;database=net;uid=root;pwd=no me acuerdo el psw;";
        private MySqlDataAdapter adapter;

        public ContactosMysqlConDataAdapter() : base()
        {
            // Configuración de Comandos
            this.adapter.InsertCommand = new MySqlCommand(
                "insert into contactos (id, nombre, apellido, email, telefono) values (@id, @nombre, @apellido, @email, @telefono)");
            this.adapter.InsertCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            this.adapter.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            this.adapter.InsertCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            this.adapter.InsertCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            this.adapter.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            this.adapter.UpdateCommand = new MySqlCommand(
                "update contactos set nombre=@nombre, apellido=@apellido, email=@email, telefono=@telefono where id=@id");
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

            try
            {
                this.adapter.Fill(contactos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }

            return contactos;
        }

        public override void aplicaCambios()
        {
            using (MySqlConnection Conn = new MySqlConnection(this.connectionString))
            {
                this.adapter.InsertCommand.Connection = Conn;
                this.adapter.UpdateCommand.Connection = Conn;
                this.adapter.DeleteCommand.Connection = Conn;

                try
                {
                    this.adapter.Update(this.misContactos);
                    Console.WriteLine("Cambios guardados en la base de datos exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar cambios: " + ex.Message);
                }
            }
        }
    }
}