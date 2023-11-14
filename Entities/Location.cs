namespace FootballTeams.Entities;

internal class Location
{
    public Guid Id { get; set; } = Guid.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public Team Team { get; set; }
}
