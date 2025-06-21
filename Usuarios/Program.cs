using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EspacioUsuario;

Console.WriteLine("Obteniendo tareas desde la API...");
HttpClient client = new HttpClient();

// Hacer la petición GET asíncrona
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users/");
response.EnsureSuccessStatusCode();

//Convierte a jason 
string json = await response.Content.ReadAsStringAsync();

List<Usuario>? usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
if (usuarios == null)
{
    Console.WriteLine("No se pudieron obtener los usuarios.");
    return;
}

// Filtrar y mostrar pendientes los primeros 5 Usuarios
foreach (var u in usuarios.Where(u => u.id <= 5))
{
    Console.WriteLine($"ID: {u.id}, Nombre: {u.name}, Email: {u.email}");
}
// Guardar en archivo JSON
await File.WriteAllTextAsync("usuarios.json", JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true }));
Console.WriteLine("\nUsuarios guardados en 'usuarios.json'.");