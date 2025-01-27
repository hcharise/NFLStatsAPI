using Project1;

public class MatchUpStats
{
    public bool neutral { get; set; }
    public string visTeamName { get; set; }
    public TeamStats visStats { get; set; }
    public string homeTeamName { get; set; }
    public TeamStats homeStats { get; set; }
    public bool isFinal { get; set; }
    public string date { get; set; }
    public void printStats()
    {
        string strFormat;

        strFormat = String.Format("{0,-11}{1, 11}", "Match Date:", date);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,-11}{1, 11}", "Final?", isFinal);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,-11}{1, 11} {2,22}|{3,22}|", "Neutral? ",neutral, $"Home: {homeTeamName}", $"Visiting: {visTeamName}");
        Console.WriteLine(strFormat);
        Console.WriteLine($"---------------------------------------------------------------------");
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "statIdCode", homeStats?.statIdCode, visStats?.statIdCode);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "gameCode", homeStats?.gameCode, visStats?.gameCode);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "teamCode", homeStats?.teamCode, visStats?.teamCode);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "gameDate", homeStats?.gameDate, visStats?.gameDate);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "rushYds", homeStats?.rushYds, visStats?.rushYds);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "rushAtt", homeStats?.rushAtt, visStats?.rushAtt);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "passYds", homeStats?.passYds, visStats?.passYds);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "passAtt", homeStats?.passAtt, visStats?.passAtt);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "passComp", homeStats?.passComp, visStats?.passComp);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "penalties", homeStats?.penalties, visStats?.penalties);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "penaltYds", homeStats?.penaltYds, visStats?.penaltYds);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "fumblesLost", homeStats?.fumblesLost, visStats?.fumblesLost);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "interceptionsThrown", homeStats?.interceptionsThrown, visStats?.interceptionsThrown);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "firstDowns", homeStats?.firstDowns, visStats?.firstDowns);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "thirdDownAtt", homeStats?.thridDownAtt, visStats?.thridDownAtt);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "thirdDownConver", homeStats?.thirdDownConver, visStats?.thirdDownConver);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "fourthDownAtt", homeStats?.fourthDownAtt, visStats?.fourthDownAtt);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "fourthDownConver", homeStats?.fourthDownConver, visStats?.fourthDownConver);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "timePoss", homeStats?.timePoss, visStats?.timePoss);
        Console.WriteLine(strFormat);
        strFormat = String.Format("{0,22}|{1,22}|{2,22}|", "score", homeStats?.score, visStats?.score);
        Console.WriteLine(strFormat);

        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine();
    }
}
