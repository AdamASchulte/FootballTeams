using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams.Entities.Seeding;

public class Seeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var cowboysLocation = new Location()
        {
            Id = Guid.NewGuid(),
            City = "Dallas",
            State = "Texas"
        };
        modelBuilder.Entity<Location>().HasData(cowboysLocation);

        var cowboysStaff = new Staff()
        {
            Id = Guid.NewGuid(),
            HeadCoach = "Mike McCarthy",
            OffensiveCoordinator = "Brain Schottenheimer",
            DefensiveCoordinator = "Dan Quinn",
            SpecialTeamsCoordinator = "John Fassel"
        };
        modelBuilder.Entity<Staff>().HasData(cowboysStaff);

        var cowboysStadium = new Stadium()
        {
            Id = Guid.NewGuid(),
            MaxCapacity = 80000,
        };
        modelBuilder.Entity<Stadium>().HasData(cowboysStadium);

        var cowboys = new Team
        {
            Id = Guid.NewGuid(),
            Name = "Dallas Cowboys",
            OwnerName = "Jerry Jones",
            LocationId = cowboysLocation.Id,
            Mascot = "Rowdy",
            StaffId = cowboysStaff.Id,
            StadiumId = cowboysStadium.Id,
        };
        modelBuilder.Entity<Team>().HasData(cowboys);

        var cowboys2022Stats = new TeamStats()
        {
            Id = Guid.NewGuid(),
            Season = 2022,
            Wins = 12,
            Losses = 5,
            TeamId = cowboys.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(cowboys2022Stats);

        var cowboys2021Stats = new TeamStats()
        {
            Id = Guid.NewGuid(),
            Season = 2021,
            Wins = 12,
            Losses = 5,
            TeamId = cowboys.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(cowboys2021Stats);

        var cowboys2020Stats = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2020,
            Wins = 6,
            Losses = 10,
            TeamId = cowboys.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(cowboys2020Stats);

        var bengalsLocation = new Location
        {
            Id = Guid.NewGuid(),
            City = "Cincinnati",
            State = "Ohio"
        };
        modelBuilder.Entity<Location>().HasData(bengalsLocation);

        var bengalsStaff = new Staff
        {
            Id = Guid.NewGuid(),
            HeadCoach = "Zac Taylor",
            OffensiveCoordinator = "Brian Callahan",
            DefensiveCoordinator = "Lou Anarumo",
            SpecialTeamsCoordinator = "Darrin Simmons"
        };
        modelBuilder.Entity<Staff>().HasData(bengalsStaff);

        var bengalsStadium = new Stadium
        {
            Id = Guid.NewGuid(),
            MaxCapacity = 65515,
        };
        modelBuilder.Entity<Stadium>().HasData(bengalsStadium);

        var bengals = new Team
        {
            Id = Guid.NewGuid(),
            Name = "Cincinnati Bengals",
            OwnerName = "Michael Brown",
            LocationId = bengalsLocation.Id,
            Mascot = "Who Dey",
            StaffId = bengalsStaff.Id,
            StadiumId = bengalsStadium.Id,
        };

        modelBuilder.Entity<Team>().HasData(bengals);

        var bengalsStats2022 = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2022,
            Wins = 12,
            Losses = 4,
            TeamId = bengals.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(bengalsStats2022);

        var bengalsStats2021 = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2021,
            Wins = 10,
            Losses = 7,
            TeamId = bengals.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(bengalsStats2021);

        var bengalsStats2020 = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2020,
            Wins = 4,
            Losses = 11,
            TeamId = bengals.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(bengalsStats2020);

        var saintsLocation = new Location
        {
            Id = Guid.NewGuid(),
            City = "New Orleans",
            State = "Louisiana"
        };
        modelBuilder.Entity<Location>().HasData(saintsLocation);

        var saintsStaff = new Staff
        {
            Id = Guid.NewGuid(),
            HeadCoach = "Dennis Allen",
            OffensiveCoordinator = "Pete Carmichael Jr.",
            DefensiveCoordinator = "Joe Woods",
            SpecialTeamsCoordinator = "Darren Rizzi"
        };
        modelBuilder.Entity<Staff>().HasData(saintsStaff);

        var saintsStadium = new Stadium
        {
            Id = Guid.NewGuid(),
            MaxCapacity = 76468,
        };
        modelBuilder.Entity<Stadium>().HasData(saintsStadium);

        var saints = new Team
        {
            Id = Guid.NewGuid(),
            Name = "New Orleans Saints",
            OwnerName = "Gayle Benson",
            LocationId = saintsLocation.Id,
            Mascot = "Sir Saint",
            StaffId = saintsStaff.Id,
            StadiumId = saintsStadium.Id,
        };
        modelBuilder.Entity<Team>().HasData(saints);

        var saints2022Stats = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2022,
            Wins = 7,
            Losses = 10,
            TeamId = saints.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(saints2022Stats);  

        var saints2021Stats = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2021,
            Wins = 9,
            Losses = 8,
            TeamId = saints.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(saints2021Stats);

        var saints2020Stats = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2020,
            Wins = 12,
            Losses = 4,
            TeamId = saints.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(saints2020Stats);

        var patriotsLocation = new Location
        {
            Id = Guid.NewGuid(),
            City = "Foxborough",
            State = "Massachusetts"
        };
        modelBuilder.Entity<Location>().HasData(patriotsLocation);

        var patriotsStaff = new Staff
        {
            Id = Guid.NewGuid(),
            HeadCoach = "Bill Belichick",
            OffensiveCoordinator = "Bill O'Brien",
            DefensiveCoordinator = "Jerod Mayo",
            SpecialTeamsCoordinator = "Cameron Achord"
        };
        modelBuilder.Entity<Staff>().HasData(patriotsStaff);

        var patriotsStadium = new Stadium
        {
            Id = Guid.NewGuid(),
            MaxCapacity = 64628,
        };
        modelBuilder.Entity<Stadium>().HasData(patriotsStadium);

        var patriots = new Team
        {
            Id = Guid.NewGuid(),
            Name = "New England Patriots",
            OwnerName = "Robert Kraft",
            LocationId = patriotsLocation.Id,
            Mascot = "Pat Patriot",
            StaffId = patriotsStaff.Id,
            StadiumId = patriotsStadium.Id,
        };
        modelBuilder.Entity<Team>().HasData(patriots);

        var patriotsStats2022 = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2022,
            Wins = 8,
            Losses = 9,
            TeamId = patriots.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(patriotsStats2022);

        var patriotsStats2021 = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2021,
            Wins = 10,
            Losses = 7,
            TeamId = patriots.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(patriotsStats2021);

        var patriotsStats2020 = new TeamStats
        {
            Id = Guid.NewGuid(),
            Season = 2020,
            Wins = 7,
            Losses = 9,
            TeamId = patriots.Id
        };
        modelBuilder.Entity<TeamStats>().HasData(patriotsStats2020);
    }
}
