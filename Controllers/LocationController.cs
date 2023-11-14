using FootballTeams.DTOs;
using FootballTeams.Entities;
using Spectre.Console;

namespace FootballTeams.Controllers;

internal static class LocationController
{
    internal static LocationDTO GetLocation(string city)
    {
        using ApplicationDbContext _context = new ApplicationDbContext();

        var location = _context.Locations.FirstOrDefault(l => l.City == city);

        LocationDTO locationDto = new LocationDTO()
        {
            City = location.City,
            State = location.State,
        };

        return locationDto;
    }

    internal static void AddLocation()
    {
        var city = AnsiConsole.Ask<string>("Location's City");
        var state = AnsiConsole.Ask<string>("Location's state");
        using var _context = new ApplicationDbContext();
        _context.Add(new Location
        {
            City = city,
            State = state
        });

        _context.SaveChanges();
    }
}
