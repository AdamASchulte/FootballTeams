using FootballTeams.DTOs;
using FootballTeams.Entities;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace FootballTeams.Controllers;

internal class PlayerController
{
    public static void DeletePlayer(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.FirstOrDefault(t => t.Name == teamName);
        if (team == null)
        {
            AnsiConsole.WriteLine("Critical Error, team cannot be found");
            return;
        }

        while(true)
        {
            string playerName = AnsiConsole.Ask<string>($"Please enter the name of the player you want to remove from the database on {teamName}");

            Player player = _context.Players.FirstOrDefault(p => p.Name.ToLower().Trim() == playerName.ToLower().Trim());
            if (player == null)
            {
                string tryAgain = AnsiConsole.Ask<string>($"Player {playerName} not found on {teamName}. Would you like to try again? Type YES or NO and press enter");
                if (tryAgain.ToLower().Trim() != "yes")
                {
                    return;
                }
            }
            else
            {
                _context.Players.Remove(player);

                _context.SaveChanges();

                AnsiConsole.WriteLine($"Player {playerName} Successfully removed from the database\n");

                return;
            }
        }
    }

    public static void UpdatePlayerSalary(string teamName)
    {
        using var _context = new ApplicationDbContext();

        Team team = _context.Teams.FirstOrDefault(t => t.Name == teamName);
        if (team == null)
        {
            AnsiConsole.WriteLine("Critical Error, Team could not be found");
            return;
        }

        while (true)
        {
            string playerName = AnsiConsole.Ask<string>("Please enter the name of the player whose salary you want to modify\nPlayer Names can be found in the ReadMe file");

            Player player = _context.Players.FirstOrDefault(p => p.Name.ToLower().Trim() == playerName.ToLower().Trim() && p.TeamId == team.Id);
            if (player == null)
            {
                string tryAgain = AnsiConsole.Ask<string>($"Player with name {playerName} could not be found on team {teamName}. Would you like to try again? Type YES or NO and press enter");
                if (tryAgain.ToLower().Trim() != "yes")
                {
                    return;
                }
            }
            else
            {
                int salary = AnsiConsole.Ask<int>($"Please enter the new salary of {player.Name}");
                player.Salary = salary;

                _context.Players.Update(player);

                _context.SaveChanges();

                AnsiConsole.WriteLine($"Player {playerName} now has salary: ${salary}\n");

                return;
            }
        }
    }

    public static void AddPlayer(string teamName)
    {
        using var _context = new ApplicationDbContext();

        string playerName = "";
        bool playerNameisDuplicate = true;

        while (playerNameisDuplicate)
        {
            playerName = AnsiConsole.Ask<string>("Please enter the name of the new player");
            if(!_context.Players.Any(p => p.Name.ToLower().Trim() == playerName))
            {
                playerNameisDuplicate = false;
            }
            else
            {
                AnsiConsole.WriteLine($"There already exists a player with this name on {teamName}");
            }
        }

        int jerseyNumber = -1;
        bool jerseyNumberisDuplicate = true;
        while(jerseyNumberisDuplicate)
        {
            jerseyNumber = AnsiConsole.Ask<int>("Please enter the jersey number of the new player");
            if(!_context.Players.Include(p => p.Team).Any(p => p.Team.Name == teamName && p.JerseyNumber == jerseyNumber))
            {
                jerseyNumberisDuplicate = false;
            }
            else
            {
                AnsiConsole.WriteLine($"There already exists a player with that number on {teamName}");
            }
        }

        int salary = AnsiConsole.Ask<int>("Please enter the salary of the new player");

        string position = AnsiConsole.Ask<string>("Please enter the position of the new player\n");

        Team team = _context.Teams.FirstOrDefault(t => t.Name == teamName);
        if(team == null)
        {
            AnsiConsole.WriteLine("Critical Error, Team could not be found\n");
            return;
        }

        Player player = new Player()
        {
            Name = playerName,
            JerseyNumber = jerseyNumber,
            Salary = salary,
            Position = position,
            TeamId = team.Id
        };

        

        _context.Add(player);

        _context.SaveChanges();
    }
    public static void GetPlayersByTeam(string teamName)
    {
        using var _context = new ApplicationDbContext();
        List<PlayerDTO> players = _context.Players.Include(p => p.Team).Where(p => p.Team.Name == teamName).OrderBy(p => p.JerseyNumber)
            .Select(p => new PlayerDTO
            {
                Name = p.Name,
                TeamName = p.Team.Name,
                JerseyNumber = p.JerseyNumber,
                Position = p.Position,
                Salary = p.Salary
            }).ToList();

        string response = $"All Players on {teamName}:\n";
        foreach (var player in players)
        {
            string currentPlayer = $"{player.Name}:\n\tJersey Number: {player.JerseyNumber}\n\tPosition: {player.Position}\n\tSalary: ${player.Salary}\n";
            response += currentPlayer;
        }

        AnsiConsole.WriteLine(response);

        return;
    }

    public static void GetPlayerByName(string teamName)
    {
        using var _context = new ApplicationDbContext();
        while(true)
        {
            string playerName = AnsiConsole.Ask<string>($"Enter the name of the Player on {teamName} that you would like to search");

            Player player = _context.Players.Include(p => p.Team).FirstOrDefault(p => p.Name.ToLower().Trim() == playerName.ToLower().Trim() && p.Team.Name == teamName);
            if (player == null)
            {
                string tryAgain = AnsiConsole.Ask<string>($"Player could not be on {teamName} with name {playerName}. Would you like to try again? Type YES or NO\n");
                if(tryAgain.ToLower().Trim() != "yes")
                {
                    return;
                }
            }
            else
            {
                PlayerDTO playerToReturn = new PlayerDTO
                {
                    Name = player.Name,
                    TeamName = player.Team.Name,
                    JerseyNumber = player.JerseyNumber,
                    Position = player.Position,
                    Salary = player.Salary
                };

                string response = $"Info for {playerToReturn.Name}:\nTeamName: {playerToReturn.TeamName}\nJerseryNumber: {playerToReturn.JerseyNumber}\nPosition: {playerToReturn.Position}\nSalary: ${playerToReturn.Salary}\n";
                AnsiConsole.Write(response);

                return;
            }
        }
    }

    public static void GetPlayerByJerseryNumber(string teamName)
    {
        using var _context = new ApplicationDbContext();

        while(true)
        {
            int jerseyNumber = AnsiConsole.Ask<int>($"Please enter the jsersey number of the player on {teamName} that you would like to search for");
            var player = _context.Players.Include(p => p.Team).FirstOrDefault(p => p.Team.Name == teamName && p.JerseyNumber == jerseyNumber);

            if (player == null)
            {
                AnsiConsole.WriteLine($"There is no player on the {teamName} with the jersey number {jerseyNumber}\n");
                string tryAgain = AnsiConsole.Ask<string>("Would you like to try again? Type YES or NO and press enter");
                if (tryAgain.ToLower().Trim() != "yes")
                {
                    return;
                }
            }
            else
            {
                PlayerDTO playerToReturn = new PlayerDTO()
                {
                    Name = player.Name,
                    TeamName = player.Team.Name,
                    JerseyNumber = player.JerseyNumber,
                    Position = player.Position,
                    Salary = player.Salary
                };

                string response = $"Info for {playerToReturn.Name}\nTeamName: {playerToReturn.TeamName}\nJerseyNumber: {playerToReturn.JerseyNumber}\nPosition: {playerToReturn.Position}\nSalary: ${playerToReturn.Salary}\n";
                AnsiConsole.WriteLine(response);

                return;
            }
        }
    }
}
