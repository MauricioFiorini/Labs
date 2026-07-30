using System;
using System.Data; // Necesario para DataTable y DataRow

namespace Lab02
{
    public class ManejadorArchivo
    {
        protected DataTable misContactos = new DataTable(); // Variable de instancia

        // Métodos virtuales para ser sobrescritos por las clases hijas
        public virtual void getTabla() { }
        public virtual void aplicaCambios() { }

        public void listar()
        {
            foreach (DataColumn col in misContactos.Columns)
            {
                Console.Write($"{col.ColumnName}\t"); // Lista nombres de columnas
            }
            Console.WriteLine();

            foreach (DataRow fila in misContactos.Rows)
            {
                // Evitamos mostrar filas que han sido marcadas para eliminarse
                if (fila.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn col in misContactos.Columns)
                    {
                        Console.Write($"{fila[col]}\t"); // Accede a las celdas
                    }
                    Console.WriteLine();
                }
            }
        }

        public void nuevaFila()
        {
            DataRow fila = misContactos.NewRow(); // Crea la fila a partir de la estructura del DataTable[cite: 2]
            foreach (DataColumn col in misContactos.Columns)
            {
                Console.Write($"Ingrese {col.ColumnName}: ");
                fila[col] = Console.ReadLine(); // Asigna valores[cite: 2]
            }
            misContactos.Rows.Add(fila); // Agrega la fila a la tabla[cite: 2]
        }

        public void editarFila()
        {
            Console.Write("Ingrese el número de fila a editar (1 en adelante): ");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = misContactos.Rows[nroFila - 1]; // Identifica la fila por índice[cite: 2]

            // El 0 se omite por ser el ID[cite: 2]
            for (int nroCol = 1; nroCol < misContactos.Columns.Count; nroCol++)
            {
                DataColumn col = misContactos.Columns[nroCol];
                Console.Write($"Ingrese {col.ColumnName}: ");
                fila[col] = Console.ReadLine();
            }
            // No es necesario agregarla al DataTable porque ya existía[cite: 2]
        }

        public void eliminarFila()
        {
            Console.Write("Ingrese el número de fila a eliminar (1 en adelante): ");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = misContactos.Rows[nroFila - 1];
            fila.Delete(); // Elimina la fila con el método Delete[cite: 2]
        }
    }
}