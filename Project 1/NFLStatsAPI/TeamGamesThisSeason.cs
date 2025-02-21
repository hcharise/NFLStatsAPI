
using System.Reflection.Metadata.Ecma335;

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
    public string teamName;

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
            Console.WriteLine("Stats retrieved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        setTeamName(); // Determines which team these stats are about, sets the teamName
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
    public void PrintSpecificGameStats(int gameNum)
    {
        Console.WriteLine($"Here are the stats for team {_teamNum} from game {gameNum}!\n", gameNum);
        _jsonFile.MatchUpStats[gameNum - 1].printStats();
    }

    // Calulates and prints the record (wins, losses, and ties) for this team
    public void PrintTeamRecord()
    {
        int wins = 0;
        int losses = 0;
        int ties = 0;

        foreach (GameStats game in _jsonFile.MatchUpStats)
        {
            if (game.homeStats.score > game.visStats.score)
            {
                wins++;
            } else if (game.visStats.score > game.homeStats.score)
            {
                losses++;
            } else
            {
                ties++;
            }
        }

        string strFormat = String.Format("{0,2}.{1,10}:{2,3} -{3,3} -{4,3}", _teamNum, teamName, wins, losses, ties);
        Console.WriteLine(strFormat);
    }

    // Determines and sets the teamName based on which team name occurs in multiple records
    private void setTeamName()
    {
        if (_jsonFile.MatchUpStats[0].homeTeamName == _jsonFile.MatchUpStats[1].homeTeamName)
        {
            teamName = _jsonFile.MatchUpStats[0].homeTeamName;
        } else if (_jsonFile.MatchUpStats[0].homeTeamName == _jsonFile.MatchUpStats[1].visTeamName)
        {
            teamName = _jsonFile.MatchUpStats[0].homeTeamName;
        } else if (_jsonFile.MatchUpStats[0].visTeamName == _jsonFile.MatchUpStats[1].homeTeamName)
        {
            teamName = _jsonFile.MatchUpStats[0].visTeamName;
        } else if (_jsonFile.MatchUpStats[0].visTeamName == _jsonFile.MatchUpStats[1].visTeamName)
        {
            teamName = _jsonFile.MatchUpStats[0].visTeamName;
        }
    }

    // Gets the number of games for this team this season, used as max
    public int getNumOfGames()
    {
        return _jsonFile.MatchUpStats.Count();
    }

}




