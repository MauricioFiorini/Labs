using System;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos la clase que se conecta a MySQL
            Contactos contactos = new ContactosMysqlConDataAdapter();

            Console.WriteLine("--- Agenda de Contactos (MySQL) ---");
            menu(contactos);
        }

        static void menu(Contactos contactos)
        {
            string rta = "";
            do
            {
                Console.WriteLine("\nMenú de Opciones:");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Agregar");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("5 - Guardar Cambios en BD");
                Console.WriteLine("6 - Salir");
                Console.Write("Elija una opción: ");

                rta = Console.ReadLine();

                switch (rta)
                {
                    case "1":
                        contactos.listar();
                        break;
                    case "2":
                        contactos.nuevaFila();
                        break;
                    case "3":
                        contactos.editarFila();
                        break;
                    case "4":
                        contactos.eliminarFila();
                        break;
                    case "5":
                        contactos.aplicaCambios();
                        break;
                    case "6":
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (rta != "6");
        }
    }
}