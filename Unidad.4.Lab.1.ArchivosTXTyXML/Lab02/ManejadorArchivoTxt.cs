using System;
using System.Data;
using System.Data.OleDb; // Namespace para conectores OLE DB[cite: 2]

namespace Lab02
{
    public class ManejadorArchivoTxt : ManejadorArchivo
    {
        // Connection string con Provider, DataSource y Extended Properties[cite: 2]
        protected string connectionString
        {
            get
            {
                // Usamos AppDomain.CurrentDomain.BaseDirectory para apuntar dinámicamente a la carpeta bin/Debug
                return $@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={AppDomain.CurrentDomain.BaseDirectory};" +
                        "Extended Properties='text;HDR=Yes;FMT=Delimited'";
            }
        }

        public override void getTabla()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM agenda.txt", connection); // Sentencia SQL[cite: 2]
                connection.Open();

                using (OleDbDataReader reader = command.ExecuteReader()) // Crea el DataReader[cite: 2]
                {
                    misContactos.Load(reader); // Carga los datos en el DataTable[cite: 2]
                }
            }
        }

        public override void aplicaCambios()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Comandos SQL para agregar, modificar y eliminar[cite: 2]
                OleDbCommand cmdInsert = new OleDbCommand("INSERT INTO agenda.txt VALUES (@id, @nombre, @apellido, @email, @telefono)", connection);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer, 0, "ID");
                cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar, 50, "Nombre");
                cmdInsert.Parameters.Add("@apellido", OleDbType.VarChar, 50, "Apellido");
                cmdInsert.Parameters.Add("@email", OleDbType.VarChar, 50, "E-mail");
                cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar, 50, "Telefono");

                // Nota: OLE DB para texto no soporta UPDATE ni DELETE de forma real[cite: 2].
                // Se incluyen a modo de ejemplo estructural de cómo se aplicaría en una BD.
                OleDbCommand cmdUpdate = new OleDbCommand("UPDATE agenda.txt SET Nombre=@nombre, Apellido=@apellido, [E-mail]=@email, Telefono=@telefono WHERE ID=@id", connection);
                // ... (Parámetros similares irían aquí)

                OleDbCommand cmdDelete = new OleDbCommand("DELETE FROM agenda.txt WHERE ID=@id", connection);
                // ... (Parámetros de ID irían aquí)

                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.InsertCommand = cmdInsert;
                adapter.UpdateCommand = cmdUpdate;
                adapter.DeleteCommand = cmdDelete;

                connection.Open();

                // Extraemos los cambios basándonos en el RowState[cite: 2]
                DataTable filasNuevas = misContactos.GetChanges(DataRowState.Added); 
                DataTable filasBorradas = misContactos.GetChanges(DataRowState.Deleted); 
                DataTable filasModificadas = misContactos.GetChanges(DataRowState.Modified); 

                if (filasNuevas != null) adapter.Update(filasNuevas);
                // Las siguientes darían error con archivos planos por falta de índice[cite: 2]
                // if (filasModificadas != null) adapter.Update(filasModificadas); 
                // if (filasBorradas != null) adapter.Update(filasBorradas);

                misContactos.AcceptChanges();
            }
        }
    }
}