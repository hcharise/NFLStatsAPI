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


    /// Displays the main menu and handles user input to navigate between options.
    public void ShowMenu()
    {
        Console.WriteLine("\nChoose an option by entering the number:");
        Console.WriteLine("\t1. Print stats from all games.");
        Console.WriteLine("\t2. Print stats from a specific game.");
        Console.WriteLine("\t3. Exit the NFL Game Stats Processor.");
    }

    public int getMenuChoice()
    {
        string input = Console.ReadLine();
        int choice;

        // Validate user input
        while (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            input = Console.ReadLine();
        }

        return choice;
    }

}
