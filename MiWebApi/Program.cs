using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EspacioPokemones;

Console.WriteLine("Consultando la API de Pokémon para obtener 3 Pokémon aleatorios...");

        HttpClient client = new HttpClient();
        Random random = new Random();
        List<Pokemon> pokemones = new List<Pokemon>();

for (int i = 0; i < 3; i++)
{
    int randomId = random.Next(1, 1025); // Ajuste de ID válido de Pokémon
    string url = $"https://pokeapi.co/api/v2/pokemon/{randomId}";


    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string jsonString = await response.Content.ReadAsStringAsync();

    var pokemon = JsonSerializer.Deserialize<Pokemon>(jsonString, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    });

    if (pokemon != null)
    {
        pokemones.Add(pokemon);
        Console.WriteLine("Datos del Pokémon:");
        Console.WriteLine($"ID: {pokemon.Id}");
        Console.WriteLine($"Nombre: {pokemon.Name}");
        Console.WriteLine($"Altura: {pokemon.Height}");
        Console.WriteLine($"Peso: {pokemon.Weight}");
        Console.WriteLine(new string('-', 30));
    }
    else
    {
        Console.WriteLine("No se pudo deserializar la respuesta.");
    }
}
 // Guardar en JSON
        await File.WriteAllTextAsync("pokemones.json", JsonSerializer.Serialize(pokemones, new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        Console.WriteLine("✔️ Datos de los 3 Pokémon guardados en 'pokemones.json'");