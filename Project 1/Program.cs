﻿using System;
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
//  - Add menu - enter JSON URL & deserialize, print out all, query specific game
//  - Add querying - change to dictionary? search by game date? can't find in search
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

            Console.WriteLine("Welcome to the NFL Game Stats Processor!\n");
            Console.WriteLine("Paste the URL at which I can access the json file:");
            string url = Console.ReadLine();

            //string url = "https://sports.snoozle.net/search/nfl/searchHandler?fileType=inline&statType=teamStats&season=2020&teamName=26";
            JsonHandler jsonHandler = new JsonHandler();
            Root jsonFile = await jsonHandler.FetchAndDeserializeJson(url);

            Console.WriteLine("\nStats retrieved successfully!");
            Console.WriteLine("Choose an option by entering the number:");
            Console.WriteLine("\t1. Print stats from all games.");
            Console.WriteLine("\t2. Print stats from a specific game.");

            string menuChoice = Console.ReadLine();
            int menuChoiceInt;
            if (int.TryParse(menuChoice, out menuChoiceInt))
            {
                switch (menuChoiceInt)
                {
                    case 1:
                        Console.WriteLine("Here are all the stats!\n");
                        foreach (var matchUpStat in jsonFile.matchUpStats)
                        {
                            matchUpStat.printStats();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Which game's stats would you like to see?");
                        break;
                    default:
                        Console.WriteLine("Not a valid menu choice.");
                        break;
                }
            } else
            {
                Console.WriteLine("Not a valid menu choice.");
            }
        }
    }
}