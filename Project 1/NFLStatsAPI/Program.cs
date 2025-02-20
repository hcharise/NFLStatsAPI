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
///  - Update capitalization to be consistent
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

        // Array to hold all team's full stats for the current season
        TeamGamesThisSeason[] allTeamsThisSeason = new TeamGamesThisSeason[32];

        // Load each team's full stats from URL/Json into array of objects
        for (int i = 0; i < 32; i++)
        {
            allTeamsThisSeason[i] = new TeamGamesThisSeason(jsonHandler, i);
            await allTeamsThisSeason[i].LoadJsonData();
        }

        // add while loop
        MenuHandler mainMenu = new MenuHandler();

        mainMenu.ShowMenu();
        int menuChoice = mainMenu.getMenuChoice();

        while (menuChoice != 3)
        {
            // Do the user's choice
            switch (menuChoice)
            {
                case 1:
                    allTeamsThisSeason[mainMenu.getTeamNum()].PrintAllStats();
                    break;
                case 2:
                    allTeamsThisSeason[mainMenu.getTeamNum()].PrintSpecificGameStats();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Not a valid menu choice.");
                    break;
            }

            mainMenu.ShowMenu();
            menuChoice = mainMenu.getMenuChoice();

        }

        Console.WriteLine("Exiting the program...");
        return; // Exit the program
    }
}
