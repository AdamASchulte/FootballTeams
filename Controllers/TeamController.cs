using FootballTeams.DTOs;
using FootballTeams.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace FootballTeams.Controllers;

internal static class TeamController
{
    public static void AddTeam()
    {
        return;
    }

    public static void UpdateTeam(UpdateTeamDTO teamDto)
    {
        using var _context = new ApplicationDbContext();

        Team teamToUpdate = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamDto.Name.ToLower().Trim());

        if (teamToUpdate == null)
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

    public static List<TeamDTO> GetAllTeams()
    {
        using var _context = new ApplicationDbContext();

        List<Team> teams = _context.Teams.ToList();
        List<TeamDTO> teamDtos = new List<TeamDTO>();

        foreach (var t in teams)
        {
            TeamDTO teamDTO = new TeamDTO
            {
                Name = t.Name,
                OwnerName = t.OwnerName,
                Mascot = t.Mascot,
                Location = new LocationDTO
                {
                    City = _context.Locations.FirstOrDefault(l => l.Id == t.LocationId).City,
                    State = _context.Locations.FirstOrDefault(l => l.Id == t.LocationId).State,
                },
                Staff = new StaffDTO
                {
                    HeadCoach = _context.Staffs.FirstOrDefault(sf => sf.Id == t.StaffId).HeadCoach,
                    OffensiveCoordinator = _context.Staffs.FirstOrDefault(sf => sf.Id == t.StaffId).OffensiveCoordinator,
                    DefensiveCoordinator = _context.Staffs.FirstOrDefault(sf => sf.Id == t.StaffId).DefensiveCoordinator,
                    SpecialTeamsCooridnator = _context.Staffs.FirstOrDefault(sf => sf.Id == t.StaffId).SpecialTeamsCoordinator
                },
                Stadium = new StadiumDTO
                {
                    MaxCapacity = _context.Stadiums.FirstOrDefault(s => s.Id == t.StadiumId).MaxCapacity
                },
                TeamStats = _context.TeamStats.Where(ts => ts.TeamId == t.Id).Select(ts => new TeamStatsDTO
                {
                    Wins = ts.Wins,
                    Losses = ts.Losses,
                    Season = ts.Season
                }).ToList(),
                Players = _context.Players.Where(p => p.TeamId == t.Id).Select(p => new PlayerDTO
                {
                    Name = p.Name,
                    TeamName = t.Name,
                    JerseyNumber = p.JerseyNumber,
                    Salary = p.Salary,
                    Position = p.Position
                }).ToList()
            };
            teamDtos.Add(teamDTO);
        }
        return teamDtos;
    }

    public static TeamDTO GetTeamByName(string name)
    {
        using var _context = new ApplicationDbContext();

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

    public static LocationDTO GetLocationByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team? team = _context.Teams.Include(t => t.Location).FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if (team == null)
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

    public static StadiumDTO GetStadiumByTeam(string name)
    {
        using var _context = new ApplicationDbContext();

        Team? team = _context.Teams.Include(t => t.Stadium).FirstOrDefault(t => t.Name.ToLower().Trim().Trim() == name.ToLower().Trim());
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

    public static StaffDTO GetStaffByTeam(string name)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.Include(t => t.Staff).FirstOrDefault(t => t.Name.ToLower().Trim() == name.ToLower().Trim());
        if (team == null)
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

    public static List<TeamStatsDTO> GetAllStatsByTeam(string name)
    {
        using var _context = new ApplicationDbContext();

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

    public static List<TeamStatsDTO> GetTeamsStats(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Guid teamId = _context.Teams.FirstOrDefault(t => t.Name == teamName).Id;

        List<TeamStatsDTO> allStatsForTeam = _context.TeamStats.Where(ts => ts.TeamId == teamId).Select(ts => new TeamStatsDTO
        {
            Wins = ts.Wins,
            Losses = ts.Losses,
            Season = ts.Season,
            TeamName = ts.Team.Name
        }).ToList();

        return allStatsForTeam;
    }

    public static TeamStatsDTO GetStatsForTeamBySeason(string teamName, int season)
    {
        using var _context = new ApplicationDbContext();

        TeamStats teamStats = _context.TeamStats.FirstOrDefault(ts => ts.Season == season && ts.Team.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if (teamStats == null)
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

    public static string GetOwnerByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        string owner = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim()).OwnerName;

        return owner;
    }

    public static string GetMascotByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        string mascot = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim()).Mascot;

        return mascot;
    }
}
