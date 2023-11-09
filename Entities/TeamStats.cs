namespace FootballTeams.Entities;

public class TeamStats
{
    public Guid Id { get; set; } = Guid.Empty;
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Season { get; set; }
    public Guid TeamId { get; set; } = Guid.Empty;
    public Team Team { get; set; }
}
