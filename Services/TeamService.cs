using FootballTeams.DTOs;
using FootballTeams.Entities;
using FootballTeams.HelperClasses;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Services;

public class TeamService
{
    private readonly ApplicationDbContext _context;
    private readonly TeamHelper _teamHelper;
    public TeamService(ApplicationDbContext context, TeamHelper teamHelper)
    {
        _context = context;
        _teamHelper = teamHelper;
    }

    public Guid AddTeam()
    {
        return Guid.Empty;
    }

    public void UpdateTeam(TeamDTO teamDto)
    {
        Team teamToUpdate = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamDto.Name.ToLower().Trim());

        //var code = _teamHelper.CalculateHashCode<StaffDTO>(teamDto.Staff);
        //if (_teamHelper.CalculateHashCode<StaffDTO>(teamDto.Staff) == _teamHelper.CalculateHashCode<Staff>(teamToUpdate.Staff)) { }
        //update team
    }

    public List<TeamDTO> GetAllTeams()
    {
        List<TeamDTO> teams = _context.Teams.Include(t => t.Staff).Include(t => t.Location).Include(t => t.TeamStats).Include(t => t.Players).Include(t => t.Stadium).Select(t => new TeamDTO
        {
            Name = t.Name,
            OwnerName = t.OwnerName,
            Mascot = t.Mascot,
            Location = new LocationDTO
            {
                City = t.Location.City,
                State = t.Location.State,
            },
            Staff = new StaffDTO
            {
                HeadCoach = t.Staff.HeadCoach,
                OffensiveCoordinator = t.Staff.OffensiveCoordinator,
                DefensiveCoordinator = t.Staff.DefensiveCoordinator,
                SpecialTeamsCooridnator = t.Staff.SpecialTeamsCoordinator
            },
            Stadium = new StadiumDTO
            {
                MaxCapacity = t.Stadium.MaxCapacity
            },
            TeamStats = t.TeamStats.Select(ts => new TeamStatsDTO
            {
                Wins = ts.Wins,
                Losses = ts.Losses
            }).ToList(),
            Players = t.Players.Select(p => new PlayerDTO
            {
                Name = p.Name,
                TeamName = t.Name,
                JerseyNumber = p.JerseyNumber,
                Salary = p.Salary,
                Position = p.Position
            }).ToList()
        }).ToList();

        return teams;
    }

    public TeamDTO GetTeamByName(string name)
    {
        Team team = _context.Teams.Include(t => t.Staff).Include(t => t.Location).Include(t => t.TeamStats).Include(t => t.Players).Include(t => t.Stadium).FirstOrDefault(t => t.Name.ToLower().Trim() == name.ToLower().Trim());

        TeamDTO teamDto = new TeamDTO
        {
            Name = team.Name,
            OwnerName = team.OwnerName,
            Mascot = team.Mascot,
            Location = new LocationDTO
            {
                City = team.Location.City,
                State = team.Location.State,
            },
            Staff = new StaffDTO
            {
                HeadCoach = team.Staff.HeadCoach,
                OffensiveCoordinator = team.Staff.OffensiveCoordinator,
                DefensiveCoordinator = team.Staff.DefensiveCoordinator,
                SpecialTeamsCooridnator = team.Staff.SpecialTeamsCoordinator
            },
            Stadium = new StadiumDTO
            {
                MaxCapacity = t.Stadium.MaxCapacity
            },
            TeamStats = team.TeamStats.Select(ts => new TeamStatsDTO
            {
                Wins = ts.Wins,
                Losses = ts.Losses
            }).ToList(),
            Players = team.Players.Select(p => new PlayerDTO
            {
                Name = p.Name,
                TeamName = team.Name,
                JerseyNumber = p.JerseyNumber,
                Salary = p.Salary,
                Position = p.Position
            }).ToList()
        };

        return teamDto;
    }
}
