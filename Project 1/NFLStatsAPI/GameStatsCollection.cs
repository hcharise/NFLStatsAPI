/// <summary>
/// Serves as the root object for deserialized JSON data, containing a list of matchup statistics.
/// This class acts as a wrapper for multiple `MatchUpStats` instances.
/// </summary>

public class GameStatsCollection
{
    public List<MatchUpStats> MatchUpStats { get; set; }
}