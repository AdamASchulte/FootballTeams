namespace FootballTeams.Entities;

internal class Player
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid TeamId { get; set; } = Guid.Empty;
    public Team Team { get; set; }
    public int JerseyNumber { get; set; }
    public int Salary {  get; set; }
    public string Position { get; set; } = string.Empty;
}
