# FootballTeams
Console Application that queries a database of NFL teams.

Made with dotnet Entity Framework Core 7.0.13, Spectre.Console, and SQLite.

Save the project to your computer either with github or from a zip file. If in a zip file, extract the project, and make sure you know the location of the file so you can access it and run it.

STEPS TO RUN:

1. This project requires Visual Studio 2022 to run. Scroll down, hover over Download button, select Community 2022. Can be downloaded here:
                    https://visualstudio.microsoft.com/vs/

2. Download ASP.Net 7: ctrl click one of the following links and click the download manually link. There are steps on the website to ensure valid installation:
					Windows: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.403-windows-x64-installer
					MacOS: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.403-macos-x64-installer
					Linux: https://learn.microsoft.com/dotnet/core/install/linux?WT.mc_id=dotnet-35129-website

3. Open FootballTeams.sln in Visual studio. This can be done by navigating the file explorer to the project folder, then right clicking FootballTeams.sln, and opening it with Visual Studio.

4. Inside the project, open the solution explorer,  right click the Project Folder "FootballTeams" directly above "Dependencies", select "Manage NuGet Packages", install the following packages:
	Microsoft.EntityFrameworkCore , Microsoft.EntityFrameworkCore.Sqlite.Core, Microsoft.EntityFrameworkCore.Tools, Newtonsoft.Jsom, Spectre.Console, SQLitePCLRaw.bundle_green

5. Next to the Run button at the top of Visual Studio, there is a tiny grey drop down arrow. Click the arrow, select "FootballTeams Debug Properties". 
   Once there, find "Working Directory" and select "Browse". Select the Folder with all the code and database file in it.

6. Run project by clicking the Run button with the green sideways arrow at the top of Visual Studio.

HOW TO USE:

Use arrow keys + enter to navigate the user interface.

List of Player Names will go here once we populate the player table.