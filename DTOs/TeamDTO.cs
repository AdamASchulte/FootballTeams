namespace FootballTeams.DTOs;
public class TeamDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Mascot { get; set; } = string.Empty;
    public LocationDTO Location { get; set; } = new LocationDTO();
    public StaffDTO Staff { get; set; } = new StaffDTO();
    public StadiumDTO Stadium { get; set; } = new StadiumDTO();
    public List<TeamStatsDTO> TeamStats { get; set; } = new List<TeamStatsDTO>();
    public List<PlayerDTO> Players { get; set; } = new List<PlayerDTO>();
}

public class UpdateTeamDTO
{
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Mascot { get; set; } = string.Empty;
    public LocationDTO Location { get; set; }
    public StaffDTO Staff { get; set; }
    public StadiumDTO Stadium { get; set; }
}
