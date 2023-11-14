using FootballTeams.DTOs;
using FootballTeams.Services;

namespace FootballTeams.Controllers;

public class TeamController
{
    private readonly TeamService _teamService;

    public TeamController(TeamService teamService)
    {
        _teamService = teamService;
    }

    public static void AddTeam()
    {
        throw new NotImplementedException();
    }

    public static void UpdateTeam()
    {
        throw new NotImplementedException ();
    }

    public List<TeamDTO> GetAllTeams()
    {
        return _teamService.GetAllTeams();
    }

    public static void GetTeamByName(string name)
    {
        throw new NotImplementedException ();
    }
}
