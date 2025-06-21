using EspacioTarea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


Console.WriteLine("Obteniendo tareas desde la API...");
HttpClient client = new HttpClient();

// Hacer la petición GET asíncrona
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
response.EnsureSuccessStatusCode();

//Convierte a jason 
string json = await response.Content.ReadAsStringAsync();

// Deserializar en lista de Tarea
List<Tarea>? tareas = JsonSerializer.Deserialize<List<Tarea>>(json);
if (tareas == null)
{
    Console.WriteLine("No se pudieron obtener las tareas.");
    return;
}

// Filtrar y mostrar pendientes
Console.WriteLine("\n=== TAREAS PENDIENTES ===");
foreach (var t in tareas.Where(t => !t.completed))
{
    Console.WriteLine($"ID: {t.id}, Título: {t.title}, Estado: Pendiente");
}

// Filtrar y mostrar completadas
Console.WriteLine("\n=== TAREAS COMPLETADAS ===");
foreach (var t in tareas.Where(t => t.completed))
{
    Console.WriteLine($"ID: {t.id}, Título: {t.title}, Estado: Completada");
}
// Serializar nuevamente a JSON
string jsonOutput = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });

// Guardar en archivo tareas.json
string filePath = Path.Combine(Directory.GetCurrentDirectory(), "tareas.json");
await File.WriteAllTextAsync(filePath, jsonOutput);

Console.WriteLine($"\n✅ Tareas guardadas en: {filePath}");