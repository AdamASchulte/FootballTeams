namespace FootballTeams.DTOs;

public class PlayerDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TeamName { get; set; } = string.Empty;
    public int JerseyNumber { get; set; }
    public int Salary { get; set; }
    public string Position { get; set; } = string.Empty;
}
