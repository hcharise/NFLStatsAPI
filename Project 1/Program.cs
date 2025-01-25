using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static async Task Main()
        {
            Item item = await JsonFileReader.ReadAsync<Item>(@"C:\Users\hchar\OneDrive\Other\Desktop\team49ers_season2020_a.json");
        }
    }

    public static class JsonFileReader
    {
        public static async Task<T> ReadAsync<T>(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }

    public class Item
    {
        public int millis;
        public string stamp;
        public DateTime datetime;
        public string light;
        public float temp;
        public float vcc;
    }
}