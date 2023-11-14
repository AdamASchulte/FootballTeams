using FootballTeams.DTOs;

namespace FootballTeams.Services;

public class LocationService
{
    private readonly ApplicationDbContext _context;
    public LocationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public LocationDTO GetLocation(Guid id)
    {
        var location = _context.Locations.FirstOrDefault(x => x.Id == id);

        if (location == null)
        {
            return null;
        }

        var locationDTO = new LocationDTO()
        {
            City = location.City,
            State = location.State,
        };

        return locationDTO;
    }
}
