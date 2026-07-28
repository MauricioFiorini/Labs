using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LabAsincronia1
{
    internal class Program5
    {

        //public static async Task IniciarEjercicio4()
        static async Task Main(string[] args)
        {
            Console.WriteLine("\n--- 5. Cancelación de Tareas Asincrónicas ---");

            // Paso 2: Utilizar CancellationTokenSource
            using (var cts = new CancellationTokenSource())
            {
                Console.WriteLine("Iniciando operación de 10 segundos...");
                Console.WriteLine("-> Presiona CUALQUIER TECLA en este momento para CANCELAR la operación <-");

                // Iniciamos la tarea asincrónica pasándole el token
                Task tareaCancelable = OperacionCancelableAsync(cts.Token);

                // Creamos una tarea secundaria rápida solo para escuchar el teclado sin bloquear el hilo principal
                Task.Run(() =>
                {
                    Console.ReadKey(true); // Espera silenciosamente a que el usuario presione una tecla
                    Console.WriteLine("\n[Usuario] ¡Tecla presionada! Solicitando cancelación...");

                    // Desencadena la señal de cancelación a través del token
                    cts.Cancel();
                });

                // Paso 3: Capturar la excepción OperationCanceledException
                try
                {
                    // Esperamos el resultado de la tarea principal
                    await tareaCancelable;
                    Console.WriteLine("\nLa operación logró completar todos sus pasos sin ser cancelada.");
                }
                catch (OperationCanceledException)
                {
                    // Aquí atrapamos la cancelación controlada
                    Console.WriteLine("\n[SISTEMA] Operación abortada exitosamente. Se capturó OperationCanceledException.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[SISTEMA] Ocurrió otro error: {ex.Message}");
                }
            }

            Console.WriteLine("\n¡Laboratorio finalizado! Presiona una tecla para salir...");
            Console.ReadKey();
        }

        // Paso 1: Método que simula 10 pasos y verifica si se solicitó cancelación
        static async Task OperacionCancelableAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                // Verifica si el CancellationTokenSource ha emitido la señal de cancelación
                // Si es así, esta línea lanza automáticamente un OperationCanceledException
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Procesando paso {i} de 10...");

                // Pasamos el token también al Delay para que interrumpa el "sueño" inmediatamente
                await Task.Delay(1000, token);
            }
        }

    }
}