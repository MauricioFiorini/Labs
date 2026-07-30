using System;
using System.Data;

namespace Lab04
{
    public class Contactos
    {
        protected DataTable misContactos;

        public Contactos()
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

        public void listar()
        {
            foreach (DataRow fila in this.misContactos.Rows)
            {
                if (fila.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn col in this.misContactos.Columns)
                    {
                        Console.WriteLine("{0}: {1}", col.ColumnName, fila[col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void nuevaFila()
        {
            DataRow fila = this.misContactos.NewRow();
            foreach (DataColumn col in this.misContactos.Columns)
            {
                Console.Write($"Ingrese {col.ColumnName}: ");
                fila[col] = Console.ReadLine();
            }
            this.misContactos.Rows.Add(fila);
        }

        public void editarFila()
        {
            Console.WriteLine("Ingrese el número de fila a editar:");
            if (int.TryParse(Console.ReadLine(), out int nroFila) && nroFila > 0 && nroFila <= this.misContactos.Rows.Count)
            {
                DataRow fila = this.misContactos.Rows[nroFila - 1];
                for (int nroCol = 1; nroCol < this.misContactos.Columns.Count; nroCol++) // El 0 se omite por ser el ID
                {
                    DataColumn col = this.misContactos.Columns[nroCol];
                    Console.Write($"Ingrese {col.ColumnName}: ");
                    fila[col] = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Número de fila inválido.");
            }
        }

        public void eliminarFila()
        {
            Console.WriteLine("Ingrese el número de fila a eliminar:");
            if (int.TryParse(Console.ReadLine(), out int fila) && fila > 0 && fila <= this.misContactos.Rows.Count)
            {
                this.misContactos.Rows[fila - 1].Delete();
                Console.WriteLine("Fila marcada para eliminar.");
            }
            else
            {
                Console.WriteLine("Número de fila inválido.");
            }
        }
    }
}
