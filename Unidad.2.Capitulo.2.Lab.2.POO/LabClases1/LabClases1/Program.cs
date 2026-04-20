using System;
using Clases;

// Instancia de A
A objetoA = new A("Hola");
Console.WriteLine("--- Prueba de Objeto A ---");
objetoA.MostrarNombre();
objetoA.M1();
objetoA.M2();
objetoA.M3();
objetoA.NombreInstancia = "Chau";
objetoA.MostrarNombre();

Console.WriteLine();

// Instancia de B
B objetoB = new B();
Console.WriteLine("--- Prueba de Objeto B ---");
objetoB.MostrarNombre();
objetoB.M1();
objetoB.M2();
objetoB.M3();
objetoB.M4();