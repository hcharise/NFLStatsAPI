using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Project1
{
    class Program
    {
        static void Main()
        {
            // Read JSON content
            string jsonContent = File.ReadAllText(@"C:\Users\hchar\OneDrive\Other\Desktop\team49ers_season2020_a.json");

            // Deserialize to the Root class
            var jsonFile = JsonConvert.DeserializeObject<Root>(jsonContent);

            if (jsonFile != null && jsonFile.matchUpStats != null)
            {
                foreach (var matchUpStat in jsonFile.matchUpStats)
                {
                    matchUpStat.printStats();

                }
            }
        }
    }
}