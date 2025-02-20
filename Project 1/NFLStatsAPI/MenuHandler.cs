/// <summary>
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


}
