using System;

namespace Clases
{
    public class B : A
    {
        // Constructor
        public B() : base("Instancia de B")
        {
        }

        // Método propio de B
        public void M4()
        {
            Console.WriteLine("Metodo del hijo Invocado");
        }
    }
}
