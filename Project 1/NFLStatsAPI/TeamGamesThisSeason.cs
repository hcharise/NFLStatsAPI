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
}