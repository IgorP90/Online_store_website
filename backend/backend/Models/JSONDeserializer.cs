using System;
using System.Diagnostics;
using System.Text.Json;

namespace backend.Models
{
    public static class JSONDeserializer
    {
        public static IEnumerable<T> JSONDeserializ<T>(string jsonFileName)
        {
            string path = File.ReadAllText($"./JSONs/{jsonFileName}");
            return JsonSerializer.Deserialize<IEnumerable<T>>(path);
        }
    }
}
