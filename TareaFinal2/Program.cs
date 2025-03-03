using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProcesamientoDeImagenes
{
    public static async Task Main(string[] args)
    {
        List<string> rutasDeImagenes = new List<string> { "imagen1.jpg", "imagen2.jpg", "imagen3.jpg" };
        List<Task> tareasHijo = new List<Task>();

        foreach (var ruta in rutasDeImagenes)
        {
            Task tareaHijo = ProcesarImagenAsync(ruta);
            tareasHijo.Add(tareaHijo);
        }

        try
        {
            await Task.WhenAll(tareasHijo);
            Console.WriteLine("Todas las imágenes han sido procesadas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error procesando imágenes: {ex.Message}");
        }
    }

    private static async Task ProcesarImagenAsync(string ruta)
    {
        try
        {
            await Task.Delay(1000); 
            Console.WriteLine($"Procesada {ruta}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error procesando {ruta}: {ex.Message}");
            throw; 
        }
    }
}