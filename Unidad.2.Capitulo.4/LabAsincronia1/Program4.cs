using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LabAsincronia1
{
    internal class Program4
    {

        public static async Task IniciarEjercicio4()
        //static async Task Main(string[] args)
        {
            Console.WriteLine("\n--- 4. Reporte de Progreso en Tareas Asincrónicas ---");
            Console.WriteLine("Iniciando tarea larga...");

            // Paso 2: Crear el objeto Progress<int> que captura y muestra el progreso en consola
            var progreso = new Progress<int>(porcentaje =>
            {
                Console.WriteLine($"Progreso de la tarea: {porcentaje}%");
            });

            // Paso 3: Ejecutar la operación pasando el objeto progreso
            await OperacionLargaConProgresoAsync(progreso);

            Console.WriteLine("\n¡Tarea finalizada con éxito! Presiona una tecla para salir...");
            Console.ReadKey();
        }

        // Paso 1: Método que simula una operación de 10 pasos y reporta el progreso
        static async Task OperacionLargaConProgresoAsync(IProgress<int> progreso)
        {
            for (int i = 1; i <= 10; i++)
            {
                // Demora de 500 ms en cada paso
                await Task.Delay(500);

                // Reportamos el porcentaje (1 * 10 = 10%, 2 * 10 = 20%, etc.)
                // Usamos ?. para asegurarnos de que no lance error si 'progreso' es nulo
                progreso?.Report(i * 10);
            }
        }

    }
}