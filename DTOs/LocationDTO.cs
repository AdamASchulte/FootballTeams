namespace FootballTeams.DTOs;

public class LocationDTO
{
    public Guid? Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}
