/// <summary>
/// Represents the statistics for a single matchup between two teams.
/// This class holds details about the match up, including team names, final score,
/// and various in-match up statistics for both home and visiting teams.
/// </summary>

public class MatchUpStats
{
    public bool neutral { get; set; }
    public string visTeamName { get; set; }
    public TeamStatsThisMatchUp visStats { get; set; }
    public string homeTeamName { get; set; }
    public TeamStatsThisMatchUp homeStats { get; set; }
    public bool isFinal { get; set; }
    public string date { get; set; }


    // Prints formatted statistics for the match up, displaying all in-match up metrics for both the home and visiting teams
    public void PrintStats()
    {
        string strFormat;

        Console.WriteLine($"Match Up Statistics - {homeTeamName} vs. {visTeamName}");

        strFormat = String.Format("{0,-11}{1, 11}", "Match Date:", date);
        Console.WriteLine(strFormat);

        strFormat = String.Format("{0,-11}{1, 11}", "Final?", isFinal);
        Console.WriteLine(strFormat);

        strFormat = String.Format("{0,-11}{1, 11} {2,22}|{3,22}|", "Neutral? ", neutral, $"Home: {homeTeamName}", $"Visiting: {visTeamName}");
        Console.WriteLine(strFormat);

        Console.WriteLine($"---------------------------------------------------------------------");

        // Print various match up statistics
        PrintStatRow("statIdCode", homeStats?.statIdCode, visStats?.statIdCode);
        PrintStatRow("gameCode", homeStats?.gameCode, visStats?.gameCode);
        PrintStatRow("teamCode", homeStats?.teamCode, visStats?.teamCode);
        PrintStatRow("gameDate", homeStats?.gameDate, visStats?.gameDate);
        PrintStatRow("rushYds", homeStats?.rushYds, visStats?.rushYds);
        PrintStatRow("rushAtt", homeStats?.rushAtt, visStats?.rushAtt);
        PrintStatRow("passYds", homeStats?.passYds, visStats?.passYds);
        PrintStatRow("passAtt", homeStats?.passAtt, visStats?.passAtt);
        PrintStatRow("passComp", homeStats?.passComp, visStats?.passComp);
        PrintStatRow("penalties", homeStats?.penalties, visStats?.penalties);
        PrintStatRow("penaltYds", homeStats?.penaltYds, visStats?.penaltYds);
        PrintStatRow("fumblesLost", homeStats?.fumblesLost, visStats?.fumblesLost);
        PrintStatRow("interceptionsThrown", homeStats?.interceptionsThrown, visStats?.interceptionsThrown);
        PrintStatRow("firstDowns", homeStats?.firstDowns, visStats?.firstDowns);
        PrintStatRow("thirdDownAtt", homeStats?.thridDownAtt, visStats?.thridDownAtt);
        PrintStatRow("thirdDownConver", homeStats?.thirdDownConver, visStats?.thirdDownConver);
        PrintStatRow("fourthDownAtt", homeStats?.fourthDownAtt, visStats?.fourthDownAtt);
        PrintStatRow("fourthDownConver", homeStats?.fourthDownConver, visStats?.fourthDownConver);
        PrintStatRow("timePoss", homeStats?.timePoss, visStats?.timePoss);
        PrintStatRow("score", homeStats?.score, visStats?.score);

        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine();
    }

    // Helper method to print a formatted row for a specific statistic.
    private void PrintStatRow(string statName, object homeValue, object visValue)
    {
        string strFormat = String.Format("{0,22}|{1,22}|{2,22}|", statName, homeValue ?? "N/A", visValue ?? "N/A");
        Console.WriteLine(strFormat);
    }

}
