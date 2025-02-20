/// <summary>
/// Entry point for the NFL Game Stats Processor application.
/// This class initializes dependencies, loads game data, and starts the menu handler.
/// </summary>
///  
/// PHASE 2
/// 
/// 
/// PHASE 1
/// Program takes URL from user, accesses data, then can print data for a single game, all games, or exit the program.
/// 
/// 
/// TO DO:
///  - Modify URL taker so that it can pull all 32 games
///         (for (1-32) {
///             get URL[i] (concat?)
///             then print team's name & number
///             for (all games in their season) {
///                 if win count as win; if loss count as loss; if tie count as tie
///             }
///             print out record
///         }
///  - Add a message queue implementation to regulate the requests going to your server
///  - Modify output to print out teams’ names, associated team number, and their season records
///  - Add for loop to count team's records
///  - Add notes above about phase 2 changes
///  - Update/redo documentation - add a diagram that shows context? try to use C4 model?, where is message queue & how does it work
///  - Figure out why teams are numbered the way they are?
///  



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

        Console.WriteLine("Enter the team number.\n");
        string input = Console.ReadLine();
        int.TryParse(input, out int teamNum);

        TeamGamesThisSeason teamA = new TeamGamesThisSeason(jsonHandler, teamNum);

        await teamA.LoadJsonData();
        teamA.PrintAllStats();

        //// Initialize the menu handler, which manages user interactions
        //MenuHandler menuHandler = new MenuHandler(jsonHandler);

        //// Load game statistics from a JSON source provided by the user
        //await menuHandler.LoadJsonData();

        //// Display the menu and process user input
        //menuHandler.ShowMenu();
    }
}
