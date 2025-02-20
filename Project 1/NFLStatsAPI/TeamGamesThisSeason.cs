/// <summary>
/// Serves as the root object for deserialized JSON data, containing a list of matchup statistics.
/// This class acts as a wrapper for multiple `MatchUpStats` instances.
/// </summary>

public class TeamGamesThisSeason
{
    public List<GameStats> MatchUpStats { get; set; }


    private readonly JsonHandler _jsonHandler; // Handles fetching and deserializing JSON data.
    private TeamGamesThisSeason _jsonFile; // Stores the deserialized game statistics.

    // Initializes a new instance of the <see cref="MenuHandler"/> class.
    public TeamGamesThisSeason(JsonHandler jsonHandler)
    {
        _jsonHandler = jsonHandler;
    }

    // Prompts the user to enter a URL, fetches JSON data from it, and deserializes it into a <see cref="GameStatsCollection"/> object.
    public async Task LoadJsonData()
    {
        // may want to pass this in as parameter from loop?
        string url = "https://sports.snoozle.net/search/nfl/searchHandler?fileType=inline&statType=teamStats&season=2020&teamName=26";
        Console.WriteLine($"Accessing URL: {url}");

        try
        {
            _jsonFile = await _jsonHandler.FetchAndDeserializeJson(url);
            Console.WriteLine("\nStats retrieved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}