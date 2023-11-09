namespace FootballTeams.DTOs;

public class StaffDTO
{
    public Guid? Id { get; set; } = Guid.Empty;
    public string HeadCoach { get; set; } = string.Empty;
    public string OffensiveCoordinator { get; set; } = string.Empty;
    public string DefensiveCoordinator { get; set;} = string.Empty;
    public string SpecialTeamsCooridnator { get; set; } = string.Empty;
}
