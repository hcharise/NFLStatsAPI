/// <summary>
/// Entry point for the NFL Game Stats Processor application.
/// This class initializes dependencies, loads game data, and starts the menu handler.
/// </summary>
///  
/// MAINTENANCE HISTORY
/// Phase 2
///  - Added ability to load stats from all 32 teams for a given season.
///  - Added option to print the record from all teams that season.
///  - Refactored classes so that menuHandler, TeamGamesThisSeason, and main Program are separated more appropriately.
/// 
/// Phase 1
///  - Program takes URL from user, accesses data, then can print data for a single game, all games, or exit the program.
/// 
/// 
/// TO DO:
///  - Add a message queue implementation to regulate the requests going to your server
///  - Update capitalization to be consistent
///  - Update // to /// or vice versa
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

class Program
{
    public static async Task Main()
    {
        // Display welcome message
        Console.WriteLine("Welcome to the NFL Game Stats Processor!\n");

        // Initialize the JSON handler, responsible for fetching and deserializing data
        JsonHandler jsonHandler = new JsonHandler();

        // Array to hold all teams' full stats for the current season
        TeamGamesThisSeason[] allTeamsThisSeason = new TeamGamesThisSeason[32];

        // Load each team's full stats from URL/Json into array of objects
        for (int i = 0; i < 32; i++)
        {
            allTeamsThisSeason[i] = new TeamGamesThisSeason(jsonHandler, i + 1);
            await allTeamsThisSeason[i].LoadJsonData(); // ADD QUEUE HERE
        }

        // Initialize a menu handler for user input/output
        MenuHandler mainMenu = new MenuHandler();

        // Display menu and get user's first choice
        mainMenu.ShowMenu();
        int menuChoice = mainMenu.getMenuChoice();

        // Continue to display menu, get user's first choice, and execute choice until user exits
        while (menuChoice != 0)
        {
            // Execute the user's choice
            switch (menuChoice)
            {
                case 1: // Printing all teams' records
                    mainMenu.printRecordHeading();
                    for (int i = 0; i < 32; i++)
                    {
                        allTeamsThisSeason[i].PrintTeamRecord();
                    }
                    break; 

                case 2: // Printing one team's stats from every game
                    allTeamsThisSeason[mainMenu.getTeamNum() - 1].PrintAllStats();
                    break; 

                case 3: // Printing one team's stats from one game
                    int teamIndex = mainMenu.getTeamNum() - 1;
                    int numOfGames = allTeamsThisSeason[teamIndex].getNumOfGames();
                    int gameNum = mainMenu.getGameNum(numOfGames);
                    allTeamsThisSeason[teamIndex].PrintSpecificGameStats(gameNum);
                    break;

                default:
                    break;
            }

            // Repeat menu to allow user another choice
            mainMenu.ShowMenu();
            menuChoice = mainMenu.getMenuChoice();

        }

        Console.WriteLine("Exiting the program...");
        return; // Exit the program
    }
}
