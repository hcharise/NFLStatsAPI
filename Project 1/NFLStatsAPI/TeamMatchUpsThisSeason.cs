
using System.Reflection.Metadata.Ecma335;

/// <summary>
/// Serves as the root object for deserialized JSON data, containing a list of matchup statistics.
/// This class acts as a wrapper for multiple `matchUpStats` instances.
/// </summary>

public class TeamMatchUpsThisSeason
{
    public List<MatchUpStats> matchUpStats { get; set; }
}

 