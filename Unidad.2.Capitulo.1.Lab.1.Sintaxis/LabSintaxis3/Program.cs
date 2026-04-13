namespace LabSintaxis3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            string[] textos = new string[cantIteraciones];
            for (int i = 0; i < cantIteraciones; i++)
            {
                Console.WriteLine("Ingrese el texto: ");
                textos[i] = Console.ReadLine();
            };
            Console.WriteLine("Textos desde atras para adelante");
            for (int t = cantIteraciones-1; t >= 0; t--)
            {

                Console.WriteLine(textos[t]);
            }
        }
    }
}
