namespace FootballTeams.DTOs;

public class TeamStatsDTO
{
    public Guid? Id { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Season { get; set; }
    public string TeamName { get; set; } = string.Empty;
}
