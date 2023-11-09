using FootballTeams.Controllers;
using FootballTeams.DTOs;
using Spectre.Console;

class Program
{
    private static void Main(string[] args)
    {
        var appIsRunning = true;

        while (appIsRunning)
        {
            var view = AnsiConsole.Prompt(
                new SelectionPrompt<ViewOptions>()
                .Title("From what point of view are you querying the teams?")
                .AddChoices(
                    ViewOptions.Management,
                    ViewOptions.Fan));

            if(view == ViewOptions.Fan)
            {
                var queryOption = AnsiConsole.Prompt(
                new SelectionPrompt<OuterMenuOptions>()
                .Title("What Team would you like to look at?")
                .AddChoices(
                    OuterMenuOptions.Teams,
                    OuterMenuOptions.Players,
                    OuterMenuOptions.TeamStats,
                    OuterMenuOptions.PlayerStats));

                switch(queryOption)
                {
                    case OuterMenuOptions.Teams:
                        var teamSelection = AnsiConsole.Prompt(
                            new SelectionPrompt<Teams>()
                            .Title("Which Team do you want to query?")
                            .AddChoices(
                                Teams.AllTeams,
                                Teams.Bengals,
                                Teams.Cowboys,
                                Teams.Patriots,
                                Teams.Saints));

                        if(teamSelection == Teams.AllTeams)
                        {
                            //List<TeamDTO> result = TeamController.GetAllTeams();
                        }
                        else if(teamSelection == Teams.Bengals)
                        {
                            TeamController.GetTeamByName("Bengals");
                        }
                        else if(teamSelection == Teams.Cowboys)
                        {
                            TeamController.GetTeamByName("Cowboys");
                        }
                        else if(teamSelection == Teams.Patriots)
                        {

                        }
                        else if( teamSelection == Teams.Saints)
                        {

                        }
                        break;
                }
            }
            else
            {
                var queryOption = AnsiConsole.Prompt(
                new SelectionPrompt<OuterMenuOptions>()
                .Title("What Team would you like to look at?")
                .AddChoices(
                    OuterMenuOptions.Teams,
                    OuterMenuOptions.Players,
                    OuterMenuOptions.Staff,
                    OuterMenuOptions.Location,
                    OuterMenuOptions.Stadium,
                    OuterMenuOptions.TeamStats,
                    OuterMenuOptions.PlayerStats));

                switch (queryOption)
                {
                    case OuterMenuOptions.Teams:
                        //Really we will once again prompt the user to see what they want to do with the team
                        var teamQueryOption = AnsiConsole.Prompt(
                            new SelectionPrompt<TeamMenuOptions>()
                            .Title("How would you like to query the teams??")
                            .AddChoices(
                                TeamMenuOptions.AllTeams,
                                TeamMenuOptions.TeamOwner,
                                TeamMenuOptions.TeamLocation,
                                TeamMenuOptions.TeamStadium,
                                TeamMenuOptions.TeamMascot,
                                TeamMenuOptions.TeamStaff,
                                TeamMenuOptions.TeamStats));
                        break;
                    case OuterMenuOptions.Players:
                        //TeamController.AddPlayers();
                        break;
                    case OuterMenuOptions.Staff:
                        //TeamController.AddStaff();
                        break;
                    case OuterMenuOptions.Location:
                        //TeamController.AddLocation();
                        break;
                    case OuterMenuOptions.Stadium:
                        //TeamController.AddStadium();
                        break;
                    case OuterMenuOptions.TeamStats:
                        //TeamController.AddTeamStats();
                        break;
                    case OuterMenuOptions.PlayerStats:
                        //TeamController.AddPlayerStats();
                        break;
                }
            }

            
        }
    }

    enum ViewOptions
    {
        Management,
        Fan
    }


    enum OuterMenuOptions
    {
        Teams,
        Players,
        Staff,
        Location,
        Stadium,
        TeamStats,
        PlayerStats
    }

    enum TeamMenuOptions
    {
        AllTeams,
        TeamByName,
        TeamOwner,
        TeamLocation,
        TeamStadium,
        TeamMascot,
        TeamStaff,
        TeamStats
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