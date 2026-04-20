using System;

namespace Clases
{
    public class A
    {

        // Propiedad
        public string NombreInstancia { get; set; }

        // Constructor por defecto
        public A()
        {
            NombreInstancia = "Instancia sin nombre";
        }

        // Constructor con parámetro
        public A(string nombre)
        {
            NombreInstancia = nombre;
        }

        // Método para mostrar el nombre
        public void MostrarNombre()
        {
            Console.WriteLine(NombreInstancia);
        }

        // Métodos M1, M2, M3
        public void M1()
        {
            Console.WriteLine("Metodo M1 invocado");
        }

        public void M2()
        {
            Console.WriteLine("Metodo M2 invocado");
        }

        public void M3()
        {
            Console.WriteLine("Metodo M3 invocado");
        }
    }
}


