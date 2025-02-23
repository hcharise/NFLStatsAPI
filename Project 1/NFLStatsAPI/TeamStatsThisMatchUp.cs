/// <summary>
/// Represents the statistical performance of a single team in a match up.
/// This class includes data such as passing yards, rushing yards, penalties,
/// turnovers, and other key performance metrics.
/// </summary>

public class TeamStatsThisMatchUp
{
    public string statIdCode { get; set; }
    public string gameCode { get; set; }
    public int teamCode { get; set; }
    public string gameDate { get; set; }
    public int rushYds { get; set; }
    public int rushAtt { get; set; }
    public int passYds { get; set; }
    public int passAtt { get; set; }
    public int passComp { get; set; }
    public int penalties { get; set; }
    public int penaltYds { get; set; }
    public int fumblesLost { get; set; }
    public int interceptionsThrown { get; set; }
    public int firstDowns { get; set; }
    public int thridDownAtt { get; set; }
    public int thirdDownConver { get; set; }
    public int fourthDownAtt { get; set; }
    public int fourthDownConver { get; set; }
    public int timePoss { get; set; }
    public int score { get; set; }
}