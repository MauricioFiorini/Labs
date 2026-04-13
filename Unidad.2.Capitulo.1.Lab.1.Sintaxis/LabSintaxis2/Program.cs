namespace LabSintaxis2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Ingrese el texto: ");
            String inputTexto = System.Console.ReadLine();

            if (inputTexto != "")
            {
                Console.WriteLine("Ingrese la opcion que quiere elegir");
                Console.WriteLine("1 - Mayuscula");
                Console.WriteLine("2 - Minuscula");
                Console.WriteLine("3 - Contar Caracteres");
                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.WriteLine();
                if (opcion.Key == ConsoleKey.D1) {
                    Console.WriteLine(inputTexto.ToUpper());
                }
                else if (opcion.Key == ConsoleKey.D2)
                {
                    Console.WriteLine(inputTexto.ToLower());
                }
                else if (opcion.Key == ConsoleKey.D3)
                {
                    Console.WriteLine(inputTexto.Length);
                }
                else
                {
                    Console.WriteLine("No se eligio opcion correcta");
                }
            }
            else
            {
                Console.WriteLine("No se encontro el texto");
            }
          
        }
    }
}