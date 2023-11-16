using FootballTeams.DTOs;
using FootballTeams.Entities;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace FootballTeams.Controllers;

internal class PlayerController
{
    public static void AddPlayer(string teamName)
    {
        using var _context = new ApplicationDbContext();

        string playerName = AnsiConsole.Ask<string>("Please enter the name of the new player");

        int jerseyNumber = AnsiConsole.Ask<int>("Please enter the jersery number of the new player");

        int salary = AnsiConsole.Ask<int>("Please enter the salary of the new player");

        string position = AnsiConsole.Ask<string>("Please enter the position of the new player");

        Player player = new Player()
        {
            Name = playerName,
            JerseyNumber = jerseyNumber,
            Salary = salary,
            Position = position,
            TeamId = _context.Teams.FirstOrDefault(t => t.Name == teamName).Id
        };

        _context.Add(player);

        _context.SaveChanges();
    }
    public static List<PlayerDTO> GetPlayersByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();
        List<PlayerDTO> players = _context.Players.Include(p => p.Team).Where(p => p.Team.Name.ToLower().Trim() == teamName.ToLower().Trim())
            .Select(p => new PlayerDTO
            {
                Name = p.Name,
                TeamName = p.Team.Name,
                JerseyNumber = p.JerseyNumber,
                Position = p.Position,
                Salary = p.Salary
            }).ToList();

        return players;
    }

    public static PlayerDTO GetPlayerByName(string teamName, string name)
    {
        using var _context = new ApplicationDbContext();
        Player player = _context.Players.Include(p => p.Team).FirstOrDefault(p => p.Name.ToLower().Trim() == name.ToLower().Trim() && p.Team.Name.ToLower().Trim() == teamName.ToLower().Trim());
        if (player == null)
        {
            return null;
        }

        PlayerDTO playerToReturn = new PlayerDTO
        {
            Name = player.Name,
            TeamName = player.Team.Name,
            JerseyNumber = player.JerseyNumber,
            Position = player.Position,
            Salary = player.Salary
        };

        return playerToReturn;
    }

    public static PlayerDTO GetPlayerByJerseryNumber(string teamName, int jerseyNumber)
    {
        using var _context = new ApplicationDbContext();

        var player = _context.Players.Include(p => p.Team).FirstOrDefault(p => p.Team.Name == teamName && p.JerseyNumber == jerseyNumber);

        if(player == null)
        {
            return null;
        }

        PlayerDTO playerDto = new PlayerDTO()
        {
            Name = player.Name,
            TeamName = player.Team.Name,
            JerseyNumber = player.JerseyNumber,
            Position = player.Position,
            Salary = player.Salary
        };

        return playerDto;
    }
}
