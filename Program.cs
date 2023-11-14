using FootballTeams.Controllers;
using Newtonsoft.Json;
using Spectre.Console;

class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            var view = AnsiConsole.Prompt(
                new SelectionPrompt<ViewOptions>()
                .Title("From what point of view are you querying the teams?")
                .AddChoices(
                    ViewOptions.Management,
                    ViewOptions.Fan,
                    ViewOptions.Quit));

            if (view == ViewOptions.Fan)
            {
                var teamSelection = AnsiConsole.Prompt(
                new SelectionPrompt<Teams>()
                .Title("What Team would you like to look at?")
                .AddChoices(
                    Teams.AllTeams,
                    Teams.Bengals,
                    Teams.Cowboys,
                    Teams.Patriots,
                    Teams.Saints));

                if (teamSelection == Teams.AllTeams)
                {
                    TeamController.GetAllTeams();
                }
                else
                {
                    string teamName = teamSelection.ToString();
                    var queryOption = AnsiConsole.Prompt(
                        new SelectionPrompt<TeamMenuOptions>()
                        .Title("How would you like to query the team?")
                        .AddChoices(
                            TeamMenuOptions.GetTeam,
                            TeamMenuOptions.GetTeamOwner,
                            TeamMenuOptions.GetTeamPlayers,
                            TeamMenuOptions.GetPlayerByJerseyNumber,
                            TeamMenuOptions.GetPlayerByName,
                            TeamMenuOptions.GetTeamStadium,
                            TeamMenuOptions.GetTeamMascot,
                            TeamMenuOptions.GetAllTeamStats,
                            TeamMenuOptions.GetTeamStatsBySeason,
                            TeamMenuOptions.GetTeamStaff,
                            TeamMenuOptions.GetTeamLocation
                            ));
                    switch (queryOption)
                    {
                        case (TeamMenuOptions.GetTeam):
                            TeamController.GetTeamByName(teamName);
                            break;
                        case (TeamMenuOptions.GetTeamOwner):
                            TeamController.GetOwnerByTeam(teamName);
                            break;
                        case (TeamMenuOptions.GetTeamPlayers):
                            PlayerController.GetPlayersByTeam(teamName);
                            break;
                        case (TeamMenuOptions.GetPlayerByJerseyNumber):
                            PlayerController.GetPlayerByJerseryNumber(teamName, 1);
                            break;
                        case (TeamMenuOptions.GetPlayerByName):
                            PlayerController.GetPlayerByName(teamName, "playerName");
                            break;
                        case (TeamMenuOptions.GetTeamStadium):
                            TeamController.GetStadiumByTeam(teamName);
                            break;
                        case (TeamMenuOptions.GetTeamMascot):
                            TeamController.GetMascotByTeam(teamName);
                            break;
                        case (TeamMenuOptions.GetAllTeamStats):
                            TeamController.GetAllStatsByTeam(teamName);
                            break;
                        case (TeamMenuOptions.GetTeamStatsBySeason):
                            TeamController.GetStatsForTeamBySeason(teamName, 2019);
                            break;
                        case (TeamMenuOptions.GetTeamStaff):
                            TeamController.GetStaffByTeam(teamName);
                            break;
                        case (TeamMenuOptions.GetTeamLocation):
                            TeamController.GetLocationByTeam(teamName);
                            break;
                    }
                }
            }
            else if (view == ViewOptions.Management)
            {
            }
            else
            {
                return;
            }
        }
    }
    enum ViewOptions
    {
        Management,
        Fan,
        Quit
    }

    enum TeamMenuOptions
    {
        GetTeam,
        GetTeamOwner,
        GetTeamLocation,
        GetTeamStadium,
        GetTeamMascot,
        GetTeamStaff,
        GetAllTeamStats,
        GetTeamStatsBySeason,
        GetTeamPlayers,
        GetPlayerByName,
        GetPlayerByJerseyNumber
    }

    enum Teams
    {
        AllTeams,
        Bengals,
        Cowboys,
        Saints,
        Patriots
    }
}