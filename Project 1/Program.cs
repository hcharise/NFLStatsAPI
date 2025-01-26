using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

// Question on Requirement 3 - Shall support generating a new JSON object
// and adding to an existing object to create a more complex object hierarchy
// ^^ Does this mean we need to actually add another object?
//    Or just be in a list format that could in theory take another object?


// TO DOS:
//  - Change to upload from URL
//  - Any other unexpected inputs? can't load file, can't parse/doesn't fit into objects, can't find search one?
//  - Add menu - enter JSON URL & deserialize, print out all, query specific game
//  - Add querying - change to dictionary? search by game date?
//  - Add comments - adequately detailed module operations and maintenance history as well as function prologue, annotated throughout
//  - Check that methods are less than 50 lines each
//  - Create documentation - model of classes and relationships

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
            } else
            {
                Console.WriteLine("Unable to parse file from path.");
            }
        }
    }
}