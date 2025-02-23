
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

/// <summary>
/// </summary>

public class TeamHandler
{
    private const string URLBase = "https://sports.snoozle.net/search/nfl/searchHandler?fileType=inline&statType=teamStats&season=2020&teamName=";
    private readonly JsonHandler _jsonHandler; // Handles fetching and deserializing JSON data.
    private TeamMatchUpsThisSeason matchUpsThisSeason; // Stores the deserialized match up statistics.
    private int _teamNum; // Stores the team's number from URL
    public string teamName; // Stores the team's name

    // Initializes a new instance of the <see cref="MenuHandler"/> class.
    public TeamHandler(JsonHandler jsonHandler, int teamNum)
    {
        _jsonHandler = jsonHandler;
        _teamNum = teamNum;
    }

    // Prompts the user to enter a URL, fetches JSON data from it, and deserializes it into a TeamMatchUpsThisSeason object.
    public async Task LoadJsonData()
    {
        string URL = URLBase + _teamNum;
        Console.WriteLine($"Accessing URL: {URL}");

        try
        {
            matchUpsThisSeason = await _jsonHandler.FetchAndDeserializeJson(URL);
            Console.WriteLine("Stats retrieved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        setTeamName(); // Determines which team these stats are about, sets the teamName
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
        matchUpsThisSeason.matchUpStats[matchUpNum - 1].printStats();
    }

    // Calulates and prints the record (wins, losses, and ties) for this team
    public void PrintTeamRecord()
    {
        int wins = 0;
        int losses = 0;
        int ties = 0;

        foreach (MatchUpStats matchUp in matchUpsThisSeason.matchUpStats)
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

        string strFormat = String.Format("{0,2}.{1,10}:{2,3} -{3,3} -{4,3}", _teamNum, teamName, wins, losses, ties);
        Console.WriteLine(strFormat);
    }

    // Determines and sets the teamName based on which team name occurs in multiple records
    private void setTeamName()
    {
        if (matchUpsThisSeason.matchUpStats[0].homeTeamName == matchUpsThisSeason.matchUpStats[1].homeTeamName)
        {
            teamName = matchUpsThisSeason.matchUpStats[0].homeTeamName;
        }
        else if (matchUpsThisSeason.matchUpStats[0].homeTeamName == matchUpsThisSeason.matchUpStats[1].visTeamName)
        {
            teamName = matchUpsThisSeason.matchUpStats[0].homeTeamName;
        }
        else if (matchUpsThisSeason.matchUpStats[0].visTeamName == matchUpsThisSeason.matchUpStats[1].homeTeamName)
        {
            teamName = matchUpsThisSeason.matchUpStats[0].visTeamName;
        }
        else if (matchUpsThisSeason.matchUpStats[0].visTeamName == matchUpsThisSeason.matchUpStats[1].visTeamName)
        {
            teamName = matchUpsThisSeason.matchUpStats[0].visTeamName;
        }
    }

    // Gets the number of match ups for this team this season, used as max
    public int getNumOfMatchUps()
    {
        return matchUpsThisSeason.matchUpStats.Count();
    }

}