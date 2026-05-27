using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=+= Menu Lab 3 =+=");
        Console.WriteLine("1. Ejercicio 1");
        Console.WriteLine("2. Ejercicio 2");
        Console.WriteLine("3. Ejercicio 3");
        Console.WriteLine("4. Ejercicio 4");
        Console.WriteLine("Seleccione un ejercicio (1-4): ");
         switch (Console.ReadLine())
        {
            case "1":
                Ejercicio1.Run();
                break;
            case "2":
                Ejercicio2.Run();
                break;
            case "3":
                Ejercicio3.Run();
                break;
            case "4":
                Ejercicio4.Run();
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, seleccione un número entre 1 y 4.");
                break;
        }
    }
}