/// <summary>
/// Serves as the root object for deserialized JSON data, containing a list of matchup statistics.
/// This class acts as a wrapper for multiple `MatchUpStats` instances.
/// </summary>

public class TeamGamesThisSeason
{
    public List<GameStats> MatchUpStats { get; set; }
    private const string URLBase = "https://sports.snoozle.net/search/nfl/searchHandler?fileType=inline&statType=teamStats&season=2020&teamName=";
    private readonly JsonHandler _jsonHandler; // Handles fetching and deserializing JSON data.
    private TeamGamesThisSeason _jsonFile; // Stores the deserialized game statistics.
    private int _teamNum;

    // Initializes a new instance of the <see cref="MenuHandler"/> class.
    public TeamGamesThisSeason(JsonHandler jsonHandler, int teamNum)
    {
        _jsonHandler = jsonHandler;
        _teamNum = teamNum;
    }

    // Prompts the user to enter a URL, fetches JSON data from it, and deserializes it into a <see cref="GameStatsCollection"/> object.
    public async Task LoadJsonData()
    {
        string URL = URLBase + _teamNum;
        Console.WriteLine($"Accessing URL: {URL}");

        try
        {
            _jsonFile = await _jsonHandler.FetchAndDeserializeJson(URL);
            Console.WriteLine("\nStats retrieved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    /// Prints statistics for all available matchups.
    public void PrintAllStats()
    {
        Console.WriteLine($"Here are all the stats for team {_teamNum} this season!\n");
        foreach (var matchUpStat in _jsonFile.MatchUpStats)
        {
            matchUpStat.printStats();
        }
    }



    /// Prompts the user to enter a specific game number and prints the corresponding statistics.
    public void PrintSpecificGameStats()
    {
        Console.WriteLine("Enter the game number that you would like to view:");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int gameNum) && gameNum > 0 && gameNum <= _jsonFile.MatchUpStats.Count)
        {
            Console.WriteLine($"Here are the stats for team {_teamNum} from game {gameNum}!\n", gameNum);
            _jsonFile.MatchUpStats[gameNum - 1].printStats();
        }
        else
        {
            Console.WriteLine("Invalid game number. Please enter a number between 1 and {0}.", _jsonFile.MatchUpStats.Count);
        }
    }
}