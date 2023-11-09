using FootballTeams.DTOs;
using FootballTeams.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Services;

public class PlayerService
{
    private readonly ApplicationDbContext _context;
    public PlayerService(ApplicationDbContext context) 
    {
        _context = context;
    }
    public List<PlayerDTO> GetPlayersByTeam(string teamName)
    {
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

    public PlayerDTO GetPlayerByName(string name)
    {
        Player player = _context.Players.Include(p => p.Team).FirstOrDefault(p => p.Name.ToLower().Trim() == name.ToLower().Trim());
        if(player == null)
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
}
