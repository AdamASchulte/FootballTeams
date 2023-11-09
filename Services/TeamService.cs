using FootballTeams.DTOs;
using FootballTeams.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Services;

public class TeamService
{
    private readonly ApplicationDbContext _context;
    public TeamService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Guid AddTeam()
    {
        return Guid.Empty;
    }

    public void UpdateTeam(UpdateTeamDTO teamDto)
    {
        Team teamToUpdate = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamDto.Name.ToLower().Trim());

        if(teamToUpdate == null)
        {
            return;
        }

        Staff staffToUpdate = _context.Staffs.FirstOrDefault(s => s.Id == teamToUpdate.StaffId);
        Location locationToUpdate = _context.Locations.FirstOrDefault(l => l.Id == teamToUpdate.LocationId);
        Stadium stadiumToUpdate = _context.Stadiums.FirstOrDefault(st => st.Id == teamToUpdate.StadiumId);

        teamToUpdate.Mascot = teamDto.Mascot;
        teamToUpdate.OwnerName = teamDto.OwnerName;

        staffToUpdate.OffensiveCoordinator = teamDto.Staff.OffensiveCoordinator;
        staffToUpdate.DefensiveCoordinator = teamDto.Staff.DefensiveCoordinator;
        staffToUpdate.SpecialTeamsCoordinator = teamDto.Staff.SpecialTeamsCooridnator;
        staffToUpdate.HeadCoach = teamDto.Staff.HeadCoach;

        locationToUpdate.City = teamDto.Location.City;
        locationToUpdate.State = teamDto.Location.State;

        stadiumToUpdate.MaxCapacity = teamDto.Stadium.MaxCapacity;

        _context.SaveChanges();
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
                MaxCapacity = team.Stadium.MaxCapacity
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

    public LocationDTO GetLocationByTeam(string name)
    {
        Team team = _context.Teams.Include(t => t.Location).FirstOrDefault(t => t.Name.ToLower().Trim() == name.ToLower().Trim());
        if(team == null)
        {
            return null;
        }

        LocationDTO location = new LocationDTO
        {
            City = team.Location.City,
            State = team.Location.State,
        };

        return location;
    }

    public StadiumDTO GetStadiumByTeam(string name)
    {
        Team team = _context.Teams.Include(t => t.Stadium).FirstOrDefault(t => t.Name.ToLower().Trim().Trim() == name.ToLower().Trim());
        if (team == null)
        {
            return null;
        }

        StadiumDTO stadium = new StadiumDTO
        {
            MaxCapacity = team.Stadium.MaxCapacity
        };

        return stadium;
    }

    public StaffDTO GetStaffByTeam(string name)
    {
        Team team = _context.Teams.Include(t => t.Staff).FirstOrDefault(t => t.Name.ToLower().Trim() == name.ToLower().Trim());
        if(team == null)
        {
            return null;
        }

        StaffDTO staff = new StaffDTO
        {
            HeadCoach = team.Staff.HeadCoach,
            OffensiveCoordinator = team.Staff.OffensiveCoordinator,
            DefensiveCoordinator = team.Staff.DefensiveCoordinator,
            SpecialTeamsCooridnator = team.Staff.SpecialTeamsCoordinator
        };

        return staff;
    }

    public List<TeamStatsDTO> GetAllStatsByTeam(string name)
    {
        Team team = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == name.ToLower().Trim());
        if (team == null)
        {
            return null;
        }

        List<TeamStatsDTO> allTeamStats = _context.TeamStats.Where(ts => ts.TeamId == team.Id).Select(ts => new TeamStatsDTO
        {
            Wins = ts.Wins,
            Losses = ts.Losses,
            Season = ts.Season,
            TeamName = team.Name,
        }).ToList();

        return allTeamStats;
    }

    public List<TeamStatsDTO> GetAllTeamsStatsBySeason(int season)
    {
        List<TeamStatsDTO> allStatsForSeason = _context.TeamStats.Include(ts => ts.Team).Where(ts => ts.Season == season).Select(ts => new TeamStatsDTO
        {
            Wins = ts.Wins,
            Losses = ts.Losses,
            Season = ts.Season,
            TeamName = ts.Team.Name
        }).ToList();

        return allStatsForSeason;
    }

    public TeamStatsDTO GetStatsForTeamBySeason(string teamName, int season)
    {
        TeamStats teamStats = _context.TeamStats.FirstOrDefault(ts => ts.Season == season && ts.Team.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if(teamStats == null)
        {
            return null;
        }
        TeamStatsDTO teamStatsDTO = new TeamStatsDTO
        { 
            Wins = teamStats.Wins,
            Losses = teamStats.Losses,
            Season = teamStats.Season,
            TeamName = teamStats.Team.Name
        };

        return teamStatsDTO;
    }
}
