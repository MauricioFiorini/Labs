using System;
using System.Data;
using System.Data.SqlClient; // Necesario para los objetos SQL

namespace LaboratorioADONetBaseDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            // ATENCIÓN: Debes verificar que el ConnectionString sea el correcto para tu entorno local.
            // Si usas SQL Server Express, puede ser "Data Source=.\SQLEXPRESS;..."
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;";
            string query = "SELECT CustomerID, CompanyName FROM Customers";

            // Declaramos la tabla según las instrucciones del Ejercicio 4
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            // =========================================================
            // EJERCICIO 4: Objeto SQLConnection y SQLDataReader
            // =========================================================
            Console.WriteLine("--- EJERCICIO 4: Llenado con SqlDataReader ---");
            using (SqlConnection myconn = new SqlConnection(connectionString))
            {
                SqlCommand mycomando = new SqlCommand(query, myconn);

                myconn.Open(); // Abrimos la conexión

                // Creamos un DataReader y llamamos al método ExecuteReader
                SqlDataReader mydr = mycomando.ExecuteReader();

                // Cargamos el objeto DataTable utilizando el método Load
                dtEmpresas.Load(mydr);

                myconn.Close(); // Cerramos la conexión
            }
            MostrarDatos(dtEmpresas);
            dtEmpresas.Clear(); // Limpiamos la tabla para el siguiente ejercicio


            // =========================================================
            // EJERCICIO 5: Objeto SQLConnection y SQLDataAdapter (.Fill)
            // =========================================================
            Console.WriteLine("\n--- EJERCICIO 5: Llenado con SqlDataAdapter ---");
            // Se realiza la misma operación pero utilizando DataAdapter en vez de DataReader
            using (SqlConnection myconn = new SqlConnection(connectionString))
            {
                // Creamos el DataAdapter pasándole el comando Select y la conexión
                SqlDataAdapter myada = new SqlDataAdapter(query, myconn);

                myconn.Open();

                // Rellenamos el contenido obtenido en el objeto DataTable
                myada.Fill(dtEmpresas);

                myconn.Close();
            }
            MostrarDatos(dtEmpresas);


            // =========================================================
            // EJERCICIO 6: SQLDataAdapter (.Update) - Modo Desconectado
            // =========================================================
            Console.WriteLine("\n--- EJERCICIO 6: Modificación y Update (Desconectado) ---");

            // Buscamos un CustomerID específico (por ejemplo 'ALFKI')
            Console.Write("Ingrese el CustomerID a buscar (ej. ALFKI): ");
            string buscarId = Console.ReadLine().ToUpper();

            DataRow[] rowsEncontradas = dtEmpresas.Select($"CustomerID = '{buscarId}'");

            if (rowsEncontradas.Length == 0)
            {
                // Si no se encuentra, enviamos un mensaje
                Console.WriteLine("No se encontró el CustomerID indicado.");
            }
            else
            {
                DataRow filaAEditar = rowsEncontradas[0];

                // Mostramos en consola el nombre original
                Console.WriteLine($"Nombre original: {filaAEditar["CompanyName"]}");

                // Solicitamos un nuevo nombre para dicha empresa
                Console.Write("Ingrese un nuevo nombre para la empresa: ");
                string nuevoNombre = Console.ReadLine();

                // Modificamos el datarow usando BeginEdit() y EndEdit()
                filaAEditar.BeginEdit();
                filaAEditar["CompanyName"] = nuevoNombre;
                filaAEditar.EndEdit();

                // Conectamos a la BD nuevamente para guardar los cambios
                using (SqlConnection myconn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter myada = new SqlDataAdapter(query, myconn);

                    // Creamos el objeto Command para realizar los cambios necesarios
                    SqlCommand updcomando = new SqlCommand("UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID", myconn);

                    // Indicamos los parámetros (nombre, tipo de dato, longitud y nombre del campo en el datatable)
                    updcomando.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
                    updcomando.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");

                    // Adjuntamos este objeto a nuestro DataAdapter
                    myada.UpdateCommand = updcomando;

                    myconn.Open();
                    // Invocamos el método .Update() indicándole el datatable
                    myada.Update(dtEmpresas);
                    myconn.Close();

                    Console.WriteLine("¡Actualización exitosa en la base de datos!");
                }
            }

            Console.WriteLine("\nPresione ENTER para salir...");
            Console.ReadLine();
        }

        // Método auxiliar para recorrer e imprimir los registros
        static void MostrarDatos(DataTable dt)
        {
            // Recorremos los registros obtenidos y los representamos en la consola
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["CustomerID"]} - {row["CompanyName"]}");
            }
        }
    }
}