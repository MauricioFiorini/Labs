using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Ejercicio4
{
    public static void Run()
    {
        List<Empleado> empleados = new List<Empleado>();
        string continuar = "s";

        // Alta de Empleado
        while (continuar.ToLower() == "s")
        {
            Empleado emp = new Empleado();

            Console.Write("Ingrese el nombre del empleado: ");
            emp.Nombre = Console.ReadLine();

            Console.Write("Ingrese la edad del empleado: ");
            emp.Edad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el sueldo del empleado: ");
            emp.Sueldo = decimal.Parse(Console.ReadLine());

            empleados.Add(emp);

            Console.Write("¿Desea ingresar otro empleado? (s/n): ");
            continuar = Console.ReadLine();
        }

        // Orden Ascendiente
        var ascendente = empleados.OrderBy(e => e.Sueldo);
        Console.WriteLine("\nEmpleados ordenados por sueldo (ascendente):");
        foreach (var emp in ascendente)
        {
            Console.WriteLine($"Nombre: {emp.Nombre}, Edad: {emp.Edad}, Sueldo: {emp.Sueldo}");
        }

        // Orden Descendiente
        var descendiente = empleados.OrderByDescending(e => e.Sueldo);
        Console.WriteLine("\nEmpleados ordenados por sueldo (descendente):");
        foreach (var emp in descendiente)
        {
            Console.WriteLine($"Nombre: {emp.Nombre}, Edad: {emp.Edad}, Sueldo: {emp.Sueldo}");
        }
    }
}