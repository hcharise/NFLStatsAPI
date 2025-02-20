﻿/// <summary>
/// Manages user interactions with the command-line menu.
/// This class is responsible for displaying menu options, processing user input, 
/// and executing corresponding actions such as loading and displaying game statistics.
/// </summary>
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

public class MenuHandler
{
    

    ///// Displays the main menu and handles user input to navigate between options.
    //public void ShowMenu()
    //{
    //    while (true)
    //    {
    //        Console.WriteLine("\nChoose an option by entering the number:");
    //        Console.WriteLine("\t1. Print stats from all games.");
    //        Console.WriteLine("\t2. Print stats from a specific game (1 - {0}).", _jsonFile.MatchUpStats.Count);
    //        Console.WriteLine("\t3. Exit the NFL Game Stats Processor.");

    //        string input = Console.ReadLine();

    //        // Validate user input
    //        if (!int.TryParse(input, out int choice))
    //        {
    //            Console.WriteLine("Invalid input. Please enter a number.");
    //            continue;
    //        }

    //        // Process the user's choice
    //        switch (choice)
    //        {
    //            case 1:
    //                PrintAllStats();
    //                break;
    //            case 2:
    //                PrintSpecificGameStats();
    //                break;
    //            case 3:
    //                Console.WriteLine("Exiting the program...");
    //                return; // Exit the method, terminating the loop and the program.
    //            default:
    //                Console.WriteLine("Not a valid menu choice.");
    //                break;
    //        }
    //    }
    //}

    ///// Prints statistics for all available matchups.
    //private void PrintAllStats()
    //{
    //    Console.WriteLine("Here are all the stats!\n");
    //    foreach (var matchUpStat in _jsonFile.MatchUpStats)
    //    {
    //        matchUpStat.printStats();
    //    }
    //}

    ///// Prompts the user to enter a specific game number and prints the corresponding statistics.
    //private void PrintSpecificGameStats()
    //{
    //    Console.WriteLine("Enter the game number that you would like to view:");
    //    string input = Console.ReadLine();

    //    if (int.TryParse(input, out int gameNumber) && gameNumber > 0 && gameNumber <= _jsonFile.MatchUpStats.Count)
    //    {
    //        Console.WriteLine("Here are the stats from game {0}!\n", gameNumber);
    //        _jsonFile.MatchUpStats[gameNumber - 1].printStats();
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid game number. Please enter a number between 1 and {0}.", _jsonFile.MatchUpStats.Count);
    //    }
    //}
}
