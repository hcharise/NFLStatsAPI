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
        int choice = convertAndValidateInt(input);

        // check here that it's within bounds?

        return choice;
    }

    // use convert and validate, also check that it's within bounds?
    public int getTeamNum()
    {
        Console.WriteLine("Enter the team number.\n");
        string input = Console.ReadLine();
        int.TryParse(input, out int teamNum);
        return teamNum;
    }

    private int convertAndValidateInt(string strInput)
    {
        int intOutput;

        // Validate user input
        while (!int.TryParse(strInput, out intOutput))
        {
            Console.WriteLine("Invalid input. Please enter a integer.");
            strInput = Console.ReadLine();
        }
        return intOutput;

    }
}
