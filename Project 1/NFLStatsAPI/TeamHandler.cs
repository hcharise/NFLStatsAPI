
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

/// <summary>
/// </summary>

public class TeamHandler
{
    private const string URLBase = "https://sports.snoozle.net/search/nfl/searchHandler?fileType=inline&statType=teamStats&season=2020&TeamName=";
    private readonly JsonHandler _jsonHandler; // Handles fetching and deserializing JSON data.
    private TeamMatchUpsThisSeason _matchUpsThisSeason; // Stores the deserialized match up statistics.
    private int _teamNum; // Stores the team's number from URL
    public string TeamName; // Stores the team's name

    // Initializes a new instance of the <see cref="MenuHandler"/> class.
    public TeamHandler(JsonHandler jsonHandler, int teamNum)
    {
        _jsonHandler = jsonHandler;
        _teamNum = teamNum;
    }

    // Prompts the user to enter a URL, fetches JSON data from it, and deserializes it into a TeamMatchUpsThisSeason object.
    public async Task LoadJsonData()
    {
        string url = URLBase + _teamNum;
        Console.WriteLine($"Accessing URL: {url}");

        try
        {
            _matchUpsThisSeason = await _jsonHandler.FetchAndDeserializeJson(url);
            Console.WriteLine("Stats retrieved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        SetTeamName(); // Determines which team these stats are about, sets the TeamName
    }


    // Prints statistics for all available matchups.
    public void PrintAllStats()
    {
        Console.WriteLine($"Here are all the stats for team {_teamNum} this season!\n");
        foreach (var matchUpStat in matchUpsThisSeason.matchUpStats)
        {
            matchUpStat.printStats();
        }
    }

    // Prompts the user to enter a specific match up number and prints the corresponding statistics.
    public void PrintSpecificMatchUpStats(int matchUpNum)
    {
        Console.WriteLine($"Here are the stats for team {_teamNum} from matchUp {matchUpNum}!\n");
        _matchUpsThisSeason.matchUpStats[matchUpNum - 1].PrintStats();
    }

    // Calulates and prints the record (wins, losses, and ties) for this team
    public void PrintTeamRecord()
    {
        int wins = 0;
        int losses = 0;
        int ties = 0;

        foreach (MatchUpStats matchUp in _matchUpsThisSeason.matchUpStats)
        {
            if (matchUp.homeStats.score > matchUp.visStats.score)
            {
                wins++;
            }
            else if (matchUp.visStats.score > matchUp.homeStats.score)
            {
                losses++;
            }
            else
            {
                ties++;
            }
        }

        string strFormat = String.Format("{0,2}.{1,10}:{2,3} -{3,3} -{4,3}", _teamNum, TeamName, wins, losses, ties);
        Console.WriteLine(strFormat);
    }

    // Determines and sets the TeamName based on which team name occurs in multiple records
    private void SetTeamName()
    {
        if (_matchUpsThisSeason.matchUpStats[0].homeTeamName == _matchUpsThisSeason.matchUpStats[1].homeTeamName)
        {
            TeamName = _matchUpsThisSeason.matchUpStats[0].homeTeamName;
        }
        else if (_matchUpsThisSeason.matchUpStats[0].homeTeamName == _matchUpsThisSeason.matchUpStats[1].visTeamName)
        {
            TeamName = _matchUpsThisSeason.matchUpStats[0].homeTeamName;
        }
        else if (_matchUpsThisSeason.matchUpStats[0].visTeamName == _matchUpsThisSeason.matchUpStats[1].homeTeamName)
        {
            TeamName = _matchUpsThisSeason.matchUpStats[0].visTeamName;
        }
        else if (_matchUpsThisSeason.matchUpStats[0].visTeamName == _matchUpsThisSeason.matchUpStats[1].visTeamName)
        {
            TeamName = _matchUpsThisSeason.matchUpStats[0].visTeamName;
        }
    }

    // Gets the number of match ups for this team this season, used as max
    public int GetNumOfMatchUps()
    {
        return _matchUpsThisSeason.matchUpStats.Count();
    }

}