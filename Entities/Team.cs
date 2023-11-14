namespace FootballTeams.Entities;

internal class Team
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public Guid LocationId { get; set; } = Guid.Empty;
    public Location Location { get; set; } 
    public string Mascot { get; set; } = string.Empty;
    public Guid StaffId { get; set; } = Guid.Empty;
    public Staff Staff { get; set;}
    public Guid StadiumId { get; set; } = Guid.Empty;
    public Stadium Stadium { get; set; }
    public List<TeamStats> TeamStats { get; set; } = new List<TeamStats>();
    public List<Player> Players { get; set; }
}
