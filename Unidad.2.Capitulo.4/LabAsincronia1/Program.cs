using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LabAsincronia1
{
    internal class Program
    {

        
        //static async Task Main(string[] args)
        public static async Task IniciarEjercicio1()
        {
            Console.WriteLine("=== Laboratorio 1: Introducción a la Asincronía ===");

            // Invocamos el método de comparación desde el Main
            await CompararSincronoVsAsincrono();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Paso 2: Operación que simula tardar 3 segundos (Sincrónica / Bloqueante)
        static void SimularOperacionPesada()
        {
            Thread.Sleep(3000);
        }

        // Paso 2: Operación que simula tardar 3 segundos (Asincrónica / No bloqueante)
        static async Task SimularOperacionPesadaAsync()
        {
            await Task.Delay(3000);
        }

        // Paso 3: Método que compara ambas ejecuciones
        static async Task CompararSincronoVsAsincrono()
        {
            var sw = new Stopwatch();

            // --- EJECUCIÓN SINCRÓNICA ---
            Console.WriteLine("\n--- INICIANDO VERSIÓN SINCRÓNICA ---");
            sw.Start();
            SimularOperacionPesada(); // El programa se congela aquí por 3 segundos
            sw.Stop();
            Console.WriteLine($"Fin de la versión sincrónica. Tiempo de ejecución: {sw.ElapsedMilliseconds} ms");

            // --- EJECUCIÓN ASINCRÓNICA ---
            sw.Restart();
            Console.WriteLine("\n--- INICIANDO VERSIÓN ASINCRÓNICA ---");

            // Llamamos a la versión asincrónica, pero sin el 'await' inmediatamente.
            Task tareaAsincrona = SimularOperacionPesadaAsync();

            // Mientras la tarea está en ejecución, permitimos que el usuario escriba en la consola
            Console.WriteLine("La tarea asincrónica está corriendo en segundo plano.");
            Console.WriteLine("¡Escribe tu nombre rápidamente y presiona Enter antes de que pasen los 3 segundos!");

            string input = Console.ReadLine();
            Console.WriteLine($"Hola {input}, pudiste escribir esto porque el hilo no se bloqueó.");

            // Ahora sí, esperamos a que la tarea asincrónica finalice para terminar el método
            await tareaAsincrona;

            sw.Stop();
            Console.WriteLine($"Fin de la versión asincrónica. Tiempo total (incluyendo lo que tardaste en escribir): {sw.ElapsedMilliseconds} ms");
        }

    }
}