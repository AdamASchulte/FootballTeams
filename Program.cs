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
                .Title("From what point of view are you querying the teams?\n(Use the up and down arrow keys to navigate and Enter to select)")
                .AddChoices(
                    ViewOptions.Management,
                    ViewOptions.Fan,
                    ViewOptions.Quit));

            if (view == ViewOptions.Fan)
            {
                ViewOnly();
            }
            else if (view == ViewOptions.Management)
            {
                bool continueManagementView = true;
                while(continueManagementView)
                {
                    var managementView = AnsiConsole.Prompt(
                    new SelectionPrompt<ManagementView>()
                    .Title("Would you like to view or manipulate data?")
                    .AddChoices(
                        ManagementView.ViewInformation,
                        ManagementView.AddOrUpdateData,
                        ManagementView.Back));
                    if (managementView == ManagementView.ViewInformation)
                    {
                        ViewOnly();
                    }
                    else if(managementView == ManagementView.AddOrUpdateData)
                    {
                        bool manipulatingTeams = true;
                        while(manipulatingTeams)
                        {
                            string teamName = "";
                            var teamToManipulate = AnsiConsole.Prompt(
                            new SelectionPrompt<Teams>()
                            .Title("Which team would you like to change data for?")
                            .AddChoices(
                                Teams.Bengals,
                                Teams.Cowboys,
                                Teams.Patriots,
                                Teams.Saints,
                                Teams.Back));
                            if(teamToManipulate == Teams.Back)
                            {
                                manipulatingTeams = false;
                            }
                            else
                            {
                                var manipulationOption = AnsiConsole.Prompt(
                                    new SelectionPrompt<AddOrUpdateOptions>()
                                    .Title("How would you like to manipulate data?")
                                    .AddChoices(
                                        AddOrUpdateOptions.UpdateMascot,
                                        AddOrUpdateOptions.UpdateOwner,
                                        AddOrUpdateOptions.UpdateStaff,
                                        AddOrUpdateOptions.AddPlayer,
                                        AddOrUpdateOptions.UpdatePlayerSalary,
                                        AddOrUpdateOptions.DeletePlayer));

                                if (teamToManipulate == Teams.Cowboys)
                                {
                                    teamName = "Dallas Cowboys";
                                }
                                else if (teamToManipulate == Teams.Patriots)
                                {
                                    teamName = "New England Patriots";
                                }
                                else if (teamToManipulate == Teams.Saints)
                                {
                                    teamName = "New Orleans Saints";
                                }
                                else if (teamToManipulate == Teams.Bengals)
                                {
                                    teamName = "Cincinnati Bengals";
                                }

                                switch (manipulationOption)
                                {
                                    case (AddOrUpdateOptions.UpdateMascot):
                                        TeamController.UpdateTeamMascot(teamName);
                                        break;
                                    case (AddOrUpdateOptions.UpdateOwner):
                                        TeamController.UpdateTeamOwner(teamName);
                                        break;
                                    case (AddOrUpdateOptions.UpdateStaff):
                                        TeamController.UpdateTeamStaff(teamName);
                                        break;
                                    case (AddOrUpdateOptions.AddPlayer): 
                                        PlayerController.AddPlayer(teamName);
                                        break;
                                    case (AddOrUpdateOptions.UpdatePlayerSalary): 
                                        PlayerController.UpdatePlayerSalary(teamName);
                                        break;
                                    case (AddOrUpdateOptions.DeletePlayer):
                                        //Implement DeletePlayer
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        continueManagementView = false;
                    }
                }
                
            }
            else
            {
                return;
            }
        }
    }

    public static void ViewOnly()
    {

        bool runLoop = true;
        while (runLoop)
        {
            var teamSelection = AnsiConsole.Prompt(
            new SelectionPrompt<Teams>()
            .Title("What Team would you like to look at?")
            .AddChoices(
                Teams.AllTeams,
                Teams.Bengals,
                Teams.Cowboys,
                Teams.Patriots,
                Teams.Saints,
                Teams.Back));

            if (teamSelection == Teams.AllTeams)
            {
                TeamController.GetAllTeams();
            }
            else if (teamSelection == Teams.Back)
            {
                runLoop = false;
            }
            else
            {
                string teamName = "";
                if (teamSelection == Teams.Cowboys)
                {
                    teamName = "Dallas Cowboys";
                }
                else if (teamSelection == Teams.Patriots)
                {
                    teamName = "New England Patriots";
                }
                else if (teamSelection == Teams.Saints)
                {
                    teamName = "New Orleans Saints";
                }
                else if (teamSelection == Teams.Bengals)
                {
                    teamName = "Cincinnati Bengals";
                }

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
                        PlayerController.GetPlayerByJerseryNumber(teamName);
                        break;
                    case (TeamMenuOptions.GetPlayerByName):
                        PlayerController.GetPlayerByName(teamName);
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
                        TeamController.GetStatsForTeamBySeason(teamName);
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
        Patriots,
        Back
    }

    enum ManagementView
    {
        ViewInformation,
        AddOrUpdateData,
        Back
    }

    enum AddOrUpdateOptions
    {
        UpdateMascot,
        UpdateOwner,
        UpdateStaff,
        AddPlayer,
        UpdatePlayerSalary,
        DeletePlayer
    }
}