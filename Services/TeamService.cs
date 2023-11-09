using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams.Services;

public class TeamService
{
    private readonly sqlite3_context _context;

    public TeamService( sqlite3_context context )
    {
        _context = context;
    }
    public Guid AddTeam()
    {
        return Guid.Empty;
    }

    public void UpdateTeam()
    {
        //update team
    }
}
