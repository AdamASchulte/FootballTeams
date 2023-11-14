using FootballTeams.DTOs;
using FootballTeams.Services;

namespace FootballTeams.Controllers;

public class LocationController
{
    private readonly LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    public LocationDTO GetLocation(Guid Id)
    {
        return _locationService.GetLocation(Id);
    }
}
