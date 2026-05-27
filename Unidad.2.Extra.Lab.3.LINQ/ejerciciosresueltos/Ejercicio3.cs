using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Ejercicio3 { 

    public static void Run() {
        ArrayList Ciudades = new ArrayList();
            
        Ciudades.Add(new Ciudad { Nombre = "Buenos Aires", CodigoPostal = 1000 });
        Ciudades.Add(new Ciudad { Nombre = "Santa Fe", CodigoPostal = 321 });
        Ciudades.Add(new Ciudad { Nombre = "San Juan", CodigoPostal = 5325 });
        Ciudades.Add(new Ciudad { Nombre = "Rosario", CodigoPostal = 2000 });
        Ciudades.Add(new Ciudad { Nombre = "Mendoza", CodigoPostal = 235 });
        Ciudades.Add(new Ciudad { Nombre = "Cordoba", CodigoPostal = 345 });
        Ciudades.Add(new Ciudad { Nombre = "La Pampa", CodigoPostal = 456 });
        Ciudades.Add(new Ciudad { Nombre = "Salta", CodigoPostal = 765 });
        Ciudades.Add(new Ciudad { Nombre = "La Plata", CodigoPostal = 457 });
        Ciudades.Add(new Ciudad { Nombre = "Nuñez", CodigoPostal = 543 });

        Console.WriteLine("Ingrse una expresion de 3 caracteres: ");

        var exp =   Console.ReadLine();
        var resultado3 = Ciudades.Cast<Ciudad>().Where(c => c.Nombre.Contains(exp) );

        foreach (var c in resultado3) {
            Console.WriteLine($"Ciudad: {c.Nombre}, Codigo Postal: {c.CodigoPostal}");
        }
    }

}