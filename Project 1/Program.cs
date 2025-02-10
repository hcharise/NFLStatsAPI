/// <summary>
/// Entry point for the NFL Game Stats Processor application.
/// This class initializes dependencies, loads game data, and starts the menu handler.
/// </summary>

using System;
using System.Threading.Tasks;
/// <summary>
/// The entry point for the NFL Game Stats Processor.
/// This class initializes necessary components and starts the menu interface.
/// </summary>
/// 

class Program
{
    public static async Task Main()
    {
        // Display welcome message
        Console.WriteLine("Welcome to the NFL Game Stats Processor!\n");

        // Initialize the JSON handler, responsible for fetching and deserializing data
        JsonHandler jsonHandler = new JsonHandler();

        // Initialize the menu handler, which manages user interactions
        MenuHandler menuHandler = new MenuHandler(jsonHandler);

        // Load game statistics from a JSON source provided by the user
        await menuHandler.LoadJsonData();

        // Display the menu and process user input
        menuHandler.ShowMenu();
    }
}
