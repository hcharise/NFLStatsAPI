/// <summary>
/// Manages user interactions with the command-line menu.
/// This class is responsible for displaying menu options, processing user input, 
/// and executing corresponding actions such as loading and displaying match up statistics.
/// </summary>
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

public class MenuHandler
{
    // Displays the main menu.
    public void ShowMenu()
    {
        Console.WriteLine("\nChoose an option by entering the number:");
        Console.WriteLine("\t1. Print records from all teams this season.");
        Console.WriteLine("\t2. Print one team's stats from all match ups this season.");
        Console.WriteLine("\t3. Print one team's stats from one match up this season.");
        Console.WriteLine("\t0. Exit the NFL Stats Processor.");
    }

    // Gets the user's input for their menu choice
    public int getMenuChoice()
    {
        string input = Console.ReadLine();
        int choice = convertAndValidateInt(input, 0, 3);
        
        return choice;
    }

    // Prompts for and gets user's input for team number
    public int getTeamNum()
    {
        Console.WriteLine("Enter the team number.");
        string input = Console.ReadLine();
        int teamNum = convertAndValidateInt(input, 1, 32);
        return teamNum;
    }

    // Prompts for and gets user's input for match up number
    public int getMatchUpNum(int max)
    {
        Console.WriteLine("Enter the match up number that you would like to view:");
        string input = Console.ReadLine();
        int matchUpNum = convertAndValidateInt(input, 1, max);
        return matchUpNum;
    }

    // Converts an input to a int (if possible) and checks if within range; reprompts if not an int within range
    private int convertAndValidateInt(string strInput, int min, int max)
    {
        int intOutput;

        // Validate user input - int and within min and max
        while (!int.TryParse(strInput, out intOutput) || intOutput < min || intOutput > max)
        {
            Console.WriteLine($"Invalid input. Please enter a integer from {min} to {max}.");
            strInput = Console.ReadLine();
        }

        return intOutput;

    }

    // Prints the heading for printing out all teams' records
    public void printRecordHeading()
    {
        Console.WriteLine("Printing records for each team this season.\n");
        string strFormat = String.Format("{0,13}:{1,3} -{2,3} -{3,3}", "TEAM", "W", "L", "T");
        Console.WriteLine(strFormat);
        Console.WriteLine("---------------------------");

    }
}
