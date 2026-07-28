using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LabAsincronia1
{
    internal class Program2
    {

        public static async Task IniciarEjercicio2()
        //static async Task Main(string[] args)
        {
            Console.WriteLine("\n--- 2. Ejecución Paralela de Tareas ---");
            await EjecutarTareasParalelasAsync();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
        static async Task OperacionCortaAsync()
        {
            await Task.Delay(1000); // 1 segundo
        }

        static async Task OperacionMediaAsync()
        {
            await Task.Delay(2000); // 2 segundos
        }

        static async Task OperacionLargaAsync()
        {
            await Task.Delay(3000); // 3 segundos
        }

        // Paso 2, 3 y 4: Comparar secuencial vs paralelo usando Task.WhenAll
        static async Task EjecutarTareasParalelasAsync()
        {
            var sw = new Stopwatch();

            // Ejecución Secuencial
            Console.WriteLine("Iniciando ejecución SECUENCIAL (esperando una tras otra)...");
            sw.Start();
            await OperacionCortaAsync();
            await OperacionMediaAsync();
            await OperacionLargaAsync();
            sw.Stop();
            Console.WriteLine($"Tiempo de ejecución secuencial: {sw.ElapsedMilliseconds} ms");

            // Ejecución Paralela
            sw.Restart();
            Console.WriteLine("\nIniciando ejecución PARALELA con Task.WhenAll...");

            // Iniciamos las tres tareas pero NO usamos 'await' en cada una inmediatamente
            Task tarea1 = OperacionCortaAsync();
            Task tarea2 = OperacionMediaAsync();
            Task tarea3 = OperacionLargaAsync();

            // Usamos Task.WhenAll para esperar a que TODAS terminen al mismo tiempo
            await Task.WhenAll(tarea1, tarea2, tarea3);

            sw.Stop();
            Console.WriteLine($"Tiempo de ejecución paralela: {sw.ElapsedMilliseconds} ms");
        }

    }
}