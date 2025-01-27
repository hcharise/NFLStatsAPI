using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Question on Requirement 3 - Shall support generating a new JSON object
// and adding to an existing object to create a more complex object hierarchy
// ^^ Does this mean we need to actually add another object?
//    Or just be in a list format that could in theory take another object?


// TO DOS:
//  - Any other unexpected inputs? can't load file, can't parse/doesn't fit into objects, can't find search one?
//  - Add menu - enter JSON URL & deserialize, print out all, query specific game
//  - Add querying - change to dictionary? search by game date?
//  - Add comments - adequately detailed module operations and maintenance history as well as function prologue, annotated throughout
//  - Check that methods are less than 50 lines each
//  - Create documentation - model of classes and relationships
//  - Rename Root and put all json handling into json package?

namespace Project1
{
    class Program
    {
        public static async Task Main()
        {
            string url = "https://sports.snoozle.net/search/nfl/searchHandler?fileType=inline&statType=teamStats&season=2020&teamName=26";
            JsonHandler jsonHandler = new JsonHandler();
            Root jsonFile = await jsonHandler.FetchAndDeserializeJson(url);

            if (jsonFile != null && jsonFile.matchUpStats != null)
            {
                foreach (var matchUpStat in jsonFile.matchUpStats)
                {
                    matchUpStat.printStats();

                }
            }
            else
            {
                Console.WriteLine("Unable to parse file from path.");
            }
        }

        
    }
}