using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Ejercicio1
{ 
    public static void Run() { 

        string[] provincias = { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Cordoba", "Corrientes", "Entre Rios", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquen", "Rio Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego", "Tucuman" };
        
        var resultado = provincias.Where(p => p.StartsWith("T") || p.StartsWith("S"));
        
        foreach ( var p in resultado )
        {
            Console.WriteLine(p);
        }
    }
}