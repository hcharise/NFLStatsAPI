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


    /// Displays the main menu and handles user input to navigate between options.
    public void ShowMenu()
    {
        Console.WriteLine("\nChoose an option by entering the number:");
        Console.WriteLine("\t1. Print records from all teams this season.");
        Console.WriteLine("\t2. Print one team's stats from all games this season.");
        Console.WriteLine("\t3. Print one team's stats from one game this season.");
        Console.WriteLine("\t0. Exit the NFL Game Stats Processor.");
    } // need to modify

    public int getMenuChoice()
    {
        string input = Console.ReadLine();
        int choice = convertAndValidateInt(input, 0, 3);
        
        return choice;
    }

    // use convert and validate, also check that it's within bounds?
    public int getTeamNum()
    {
        Console.WriteLine("Enter the team number.");
        string input = Console.ReadLine();
        int teamNum = convertAndValidateInt(input, 1, 32);
        return teamNum;
    }

    // use convert and validate, also check that it's within bounds?
    public int getGameNum(int max)
    {
        Console.WriteLine("Enter the game number that you would like to view:");
        string input = Console.ReadLine();
        int gameNum = convertAndValidateInt(input, 1, max);
        return gameNum;
    }

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

    public void printRecordHeading()
    {
        Console.WriteLine("Printing records for each team this season.\n"); // would be cool to figure out which team is which number?
        string strFormat = String.Format("{0,13}:{1,3} -{2,3} -{3,3}", "TEAM", "W", "L", "T");
        Console.WriteLine(strFormat);
        Console.WriteLine("---------------------------");

    }
}
