using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Ejercicio2
{
    public static void Run()
        {
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 15; i++)
            {
                Console.Write($"({i}/15) Ingrese un Numero: ");
                int num = int.Parse(Console.ReadLine());
                numeros.Add(num);
            }

            var resultado2 = numeros.Where(n => n > 20);
            foreach (var r in resultado2)
            {
                Console.WriteLine(r);
            }
        }
        
    }