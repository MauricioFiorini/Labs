using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LabAsincronia1
{
    internal class Program3
    {

        public static async Task IniciarEjercicio3()
        //static async Task Main(string[] args)
        {
            Console.WriteLine("\n--- 3. Manejo de Excepciones en Tareas Asincrónicas ---");
            await ProbarManejoExcepcionesAsync();

            Console.WriteLine("\nLa aplicación superó el error y continuó. Presiona una tecla para salir...");
            Console.ReadKey();
        }

        // Paso 1: Método que simula una demora y luego lanza un error
        static async Task OperacionConErrorAsync()
        {
            Console.WriteLine("Trabajando en la operación asincrónica... (demorará 2 segundos)");
            await Task.Delay(2000);

            // Lanzamos la excepción intencionalmente
            throw new InvalidOperationException("Error simulado en operación asincrónica");
        }

        // Paso 2: Método que captura el error para que el programa no se detenga
        static async Task ProbarManejoExcepcionesAsync()
        {
            try
            {
                // Invocamos el método que sabemos que puede fallar
                await OperacionConErrorAsync();

                // Esta línea nunca se ejecutará porque la excepción interrumpe el flujo
                Console.WriteLine("Operación finalizada correctamente.");
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos el error específico y mostramos el mensaje
                Console.WriteLine($"\n[ERROR CAPTURADO] La tarea falló de forma segura.");
                Console.WriteLine($"Detalle del error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Captura genérica por si ocurre otro tipo de error
                Console.WriteLine($"[ERROR GENERAL] {ex.Message}");
            }
        }

    }
}