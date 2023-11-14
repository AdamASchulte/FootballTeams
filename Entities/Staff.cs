namespace FootballTeams.Entities;

internal class Staff
{
    public Guid Id { get; set; } = Guid.Empty;
    public string HeadCoach { get; set; } = string.Empty;
    public string OffensiveCoordinator { get; set; } = string.Empty;
    public string DefensiveCoordinator { get; set; } = string.Empty;
    public string SpecialTeamsCoordinator {  get; set; } = string.Empty;
    public Team Team { get; set; }
}
