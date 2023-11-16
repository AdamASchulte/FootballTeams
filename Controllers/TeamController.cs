using FootballTeams.DTOs;
using FootballTeams.Entities;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using SQLitePCL;
using System.Formats.Asn1;
using System.Numerics;

namespace FootballTeams.Controllers;

internal static class TeamController
{
    public static void UpdateTeamMascot(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.FirstOrDefault(t => t.Name == teamName);
        if (team == null)
        {
            AnsiConsole.WriteLine("Critical Error, Team not found\n");
            return;
        }

        string mascotName = AnsiConsole.Ask<string>($"Please enter the new name for the {teamName} mascot:");

        team.Mascot = mascotName;

        _context.Teams.Update(team);

        _context.SaveChanges();

        AnsiConsole.WriteLine($"{teamName} mascot is now {mascotName}\n");

        return;
    }

    public static void UpdateTeamOwner(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.FirstOrDefault(t => t.Name == teamName);
        if (team == null)
        {
            AnsiConsole.WriteLine("Critical Error, Team not found\n");
            return;
        }

        string ownerName = AnsiConsole.Ask<string>($"Please enter the new name for the {teamName} mascot");

        team.OwnerName = ownerName;

        _context.Teams.Update(team);

        _context.SaveChanges();

        AnsiConsole.WriteLine($"{teamName} owner is now: {ownerName}\n");

        return;
    }

    public static void UpdateTeamStaff(string teamName)
    {
        using var _context = new ApplicationDbContext();
        Team team = _context.Teams.Include(t => t.Staff).FirstOrDefault(t => t.Name == teamName);
        if(team == null)
        {
            AnsiConsole.WriteLine("Critical Error, Team not found\n");
            return;
        }

        string headCoach = AnsiConsole.Ask<string>($"Please enter the new name of the head coach for the {teamName}");

        string offensiveCoordinator = AnsiConsole.Ask<string>($"Please enter the new name of the offensive coordinator for the {teamName}");

        string defensiveCoordinator = AnsiConsole.Ask<string>($"Please enter the new name of the defensive coordinator for the {teamName}");

        string specialTeamsCoordinator = AnsiConsole.Ask<string>($"Please enter the new name of the special teams coordinator for the {teamName}");

        team.Staff.OffensiveCoordinator = offensiveCoordinator;
        team.Staff.HeadCoach = headCoach;
        team.Staff.DefensiveCoordinator = defensiveCoordinator;
        team.Staff.SpecialTeamsCoordinator = specialTeamsCoordinator;

        _context.Teams.Update(team);

        _context.SaveChanges();

        string response = $"{teamName} staff is now:\nHead Coach: {headCoach}\nOffensive Coordinator: {offensiveCoordinator}\nDefensive Coordinator: {defensiveCoordinator}\nSpecial Teams Coordinator: {specialTeamsCoordinator}\n";

        AnsiConsole.WriteLine(response);

        return;
    }

    //public static void UpdateTeam(UpdateTeamDTO teamDto)
    //{
    //    using var _context = new ApplicationDbContext();

    //    Team teamToUpdate = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamDto.Name.ToLower().Trim());

    //    if (teamToUpdate == null)
    //    {
    //        return;
    //    }

    //    Staff staffToUpdate = _context.Staffs.FirstOrDefault(s => s.Id == teamToUpdate.StaffId);
    //    Location locationToUpdate = _context.Locations.FirstOrDefault(l => l.Id == teamToUpdate.LocationId);
    //    Stadium stadiumToUpdate = _context.Stadiums.FirstOrDefault(st => st.Id == teamToUpdate.StadiumId);

    //    teamToUpdate.Mascot = teamDto.Mascot;
    //    teamToUpdate.OwnerName = teamDto.OwnerName;

    //    staffToUpdate.OffensiveCoordinator = teamDto.Staff.OffensiveCoordinator;
    //    staffToUpdate.DefensiveCoordinator = teamDto.Staff.DefensiveCoordinator;
    //    staffToUpdate.SpecialTeamsCoordinator = teamDto.Staff.SpecialTeamsCooridnator;
    //    staffToUpdate.HeadCoach = teamDto.Staff.HeadCoach;

    //    locationToUpdate.City = teamDto.Location.City;
    //    locationToUpdate.State = teamDto.Location.State;

    //    stadiumToUpdate.MaxCapacity = teamDto.Stadium.MaxCapacity;

    //    _context.SaveChanges();
    //}

    public static void GetAllTeams()
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

        string response = "";

        foreach (var teamDto in teamDtos)
         {
            string playerString = "";
            string teamStatString = "";
            foreach (var player in teamDto.Players)
            {
                playerString += $"Player: {player.Name}\nJersery Number: {player.JerseyNumber}\nPosition: {player.Position}\nSalary: {player.Salary}\n";
            }
            foreach(var teamStat in teamDto.TeamStats)
            {
                teamStatString += $"Stats for the {teamStat.Season} season:\nWins: {teamStat.Wins}\nLosses: {teamStat.Losses}\n";
            }
            string currentTeam = $"Info for the {teamDto.Name}:\nOwner: {teamDto.OwnerName}\nMascot: {teamDto.Mascot}\nLocation: {teamDto.Location.City}, {teamDto.Location.State}\nStaff: \nHead Coach: {teamDto.Staff.HeadCoach}\nOffensive Coordinator: {teamDto.Staff.OffensiveCoordinator}\nDefensive Coordinator: {teamDto.Staff.DefensiveCoordinator}\nSpecial Teams Coordinator: {teamDto.Staff.SpecialTeamsCooridnator}\n{teamStatString}{playerString}\n"; ;

            response += currentTeam;
        }
        AnsiConsole.WriteLine(response);

        return;
    }
    public static void GetTeamByName(string teamName)
    {
        using var _context = new ApplicationDbContext();
        Team team = _context.Teams.Include(t => t.Staff).Include(t => t.Location).Include(t => t.TeamStats).Include(t => t.Players).Include(t => t.Stadium).FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if(team == null )
        {
            AnsiConsole.WriteLine("Critical Error, No team found with that name\n");
            return;
        }
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

        //TeamDTO fakeTeam = new TeamDTO
        //{
        //    Name = teamName,
        //    OwnerName = "Jimmy",
        //    Mascot = "fakeMascot",
        //    Location = new LocationDTO
        //    {
        //        City = "plano",
        //        State = "texas"
        //    },
        //    Staff = new StaffDTO
        //    {
        //        HeadCoach = "yomama",
        //        OffensiveCoordinator = "joe biden",
        //        DefensiveCoordinator = "trump",
        //        SpecialTeamsCooridnator = "obunga"
        //    },
        //    Stadium = new StadiumDTO { MaxCapacity = 50000},
        //    TeamStats = new List<TeamStatsDTO>() { new TeamStatsDTO { Wins = 10, Losses = 7, Season = 2019 }, new TeamStatsDTO { Wins = 11, Losses = 6, Season = 2020 } },
        //    Players = new List<PlayerDTO>() { new PlayerDTO { JerseyNumber = 1, Name = "aiden", Position = "runningback", Salary = 100000 }, new PlayerDTO { JerseyNumber = 2, Name = "aalok", Position = "runningback", Salary = 100000 } },
        //};

        string teamStatString = "";
        foreach (var teamStat in teamDto.TeamStats)
        {
            teamStatString += $"Stats for the {teamStat.Season} season:\nWins: {teamStat.Wins}\nLosses: {teamStat.Losses}\n";
        }
        string playerString = "";
        foreach(PlayerDTO player in teamDto.Players)
        {
            playerString += $"Player: {player.Name}\nJersery Number: {player.JerseyNumber}\nPosition: {player.Position}\nSalary: {player.Salary}\n";
        }

        string response = $"Info for the {teamName}:\nOwner: {teamDto.OwnerName}\nMascot: {teamDto.Mascot}\nLocation: {teamDto.Location.City}, {teamDto.Location.State}\nStaff: \nHead Coach: {teamDto.Staff.HeadCoach}\nOffensive Coordinator: {teamDto.Staff.OffensiveCoordinator}\nDefensive Coordinator: {teamDto.Staff.DefensiveCoordinator}\nSpecial Teams Coordinator: {teamDto.Staff.SpecialTeamsCooridnator}\n{teamStatString}{playerString}";
        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetLocationByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team? team = _context.Teams.Include(t => t.Location).FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if (team == null)
        {
            return;
        }

        LocationDTO location = new LocationDTO
        {
            City = team.Location.City,
            State = team.Location.State,
        };

        //LocationDTO fakeLocation = new LocationDTO
        //{
        //    City = "plano",
        //    State = "texas"
        //};

        string response = $"The {teamName} are located in {location.City}, {location.State}\n";
        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetStadiumByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team? team = _context.Teams.Include(t => t.Stadium).FirstOrDefault(t => t.Name.ToLower().Trim().Trim() == teamName.ToLower().Trim());
        if (team == null)
        {
            return;
        }

        StadiumDTO stadium = new StadiumDTO
        {
            MaxCapacity = team.Stadium.MaxCapacity
        };

        //StadiumDTO fakeStadium = new StadiumDTO
        //{
        //    MaxCapacity = 60000
        //};

        string response = $"The {teamName} stadium has a max capacity of: {stadium.MaxCapacity}\n";
        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetStaffByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.Include(t => t.Staff).FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if (team == null)
        {
            return;
        }

        StaffDTO staff = new StaffDTO
        {
            HeadCoach = team.Staff.HeadCoach,
            OffensiveCoordinator = team.Staff.OffensiveCoordinator,
            DefensiveCoordinator = team.Staff.DefensiveCoordinator,
            SpecialTeamsCooridnator = team.Staff.SpecialTeamsCoordinator
        };

        //StaffDTO fakeStaff = new StaffDTO
        //{
        //    HeadCoach = "Jim",
        //    OffensiveCoordinator = "bob",
        //    DefensiveCoordinator = "james",
        //    SpecialTeamsCooridnator = "jimbo"
        //};

        string response = $"The staff for the {teamName} is:\nHead Coach: {staff.HeadCoach}\nOffensive Coordinator: {staff.OffensiveCoordinator}\nDefensive Coordinator: {staff.DefensiveCoordinator}\nSpecial Teams Coordinator: {staff.SpecialTeamsCooridnator}\n";
        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetAllStatsByTeam(string name)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == name.ToLower().Trim());
        if (team == null)
        {
            AnsiConsole.WriteLine($"No teamStats for the {name}\n");
            return;
        }

        List<TeamStatsDTO> allTeamStats = _context.TeamStats.Where(ts => ts.TeamId == team.Id).Select(ts => new TeamStatsDTO
        {
            Wins = ts.Wins,
            Losses = ts.Losses,
            Season = ts.Season,
            TeamName = team.Name,
        }).ToList();

        //List<TeamStatsDTO> fakeStats = new List<TeamStatsDTO>()
        //{
        //    new TeamStatsDTO
        //    {
        //        Wins = 11,
        //        Losses = 4,
        //        Season = 2020,
        //    },
        //    new TeamStatsDTO
        //    {
        //        Wins = 4,
        //        Losses = 11,
        //        Season = 2019,
        //    },
        //    new TeamStatsDTO
        //    {
        //        Wins = 12,
        //        Losses = 3,
        //        Season = 2021,
        //    }
        //};

        string response = "";

        foreach(TeamStatsDTO teamStats in allTeamStats)
        {
            response += $"Stats for the {name} in {teamStats.Season}: \nWins: {teamStats.Wins}\nLosses: {teamStats.Losses}\n";
        }

        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetStatsForTeamBySeason(string teamName)
    {
        int season = AnsiConsole.Ask<int>("Please type a year 2020 or later and press enter: ");
        using var _context = new ApplicationDbContext();

        TeamStats teamStats = _context.TeamStats.Include(ts => ts.Team).FirstOrDefault(ts => ts.Season == season && ts.Team.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if (teamStats == null)
        {
            AnsiConsole.WriteLine($"No team stats for the {teamName} for the {season} season\n");
            return;
        }
        TeamStatsDTO teamStatsDto = new TeamStatsDTO
        {
            Wins = teamStats.Wins,
            Losses = teamStats.Losses,
            Season = teamStats.Season,
            TeamName = teamStats.Team.Name
        };

        //TeamStatsDTO fakeDto = new TeamStatsDTO()
        //{
        //    Wins = 12,
        //    Losses = 5,
        //    Season = 2019,
        //    TeamName = "FakeTeam"
        //};

        string response = $"Team Stats for the {teamName}: \nWins: {teamStatsDto.Wins}\nLosses: {teamStatsDto.Losses}\nSeason: {season}\n";
        AnsiConsole.WriteLine(response);

        return; ;
    }

    public static void GetOwnerByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        string owner = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim())?.OwnerName;

        string response = $"The owner of the {teamName} is {owner}\n";

        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetMascotByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();

        string mascot = _context.Teams.FirstOrDefault(t => t.Name.ToLower().Trim() == teamName.ToLower().Trim())?.Mascot;

        string response = $"The mascot for the {teamName} is {mascot}\n";

        AnsiConsole.WriteLine(response);

        return;
    }
}
