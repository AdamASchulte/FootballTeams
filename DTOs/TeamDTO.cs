namespace FootballTeams.DTOs;

public class TeamDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Mascot { get; set; } = string.Empty;
}
