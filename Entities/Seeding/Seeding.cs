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
        var cowboys = new Team
        {
            Id = Guid.NewGuid(),
            Name = "Dallas Cowboys",
            OwnerName = "Jerry Jones",
            Location = new Location
            {
                Id = Guid.NewGuid(),
                City = "Dallas",
                State = "Texas"
            },
            Mascot = "Rowdy",
            Staff = new Staff
            {
                Id = Guid.NewGuid(),
                HeadCoach = "Mike McCarthy",
                OffensiveCoordinator = "Brain Schottenheimer",
                DefensiveCoordinator = "Dan Quinn",
                SpecialTeamsCoordinator = "John Fassel"
            },
            Stadium = new Stadium
            {
                Id = Guid.NewGuid(),
                MaxCapacity = 80000,
            },
            TeamStats = new List<TeamStats>
            {
                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2022,
                    Wins = 12,
                    Losses = 5
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2021,
                    Wins = 12,
                    Losses = 5
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2020,
                    Wins = 6,
                    Losses = 10
                }
            }
        };

        modelBuilder.Entity<Team>().HasData(cowboys);

        var bengals = new Team
        {
            Id = Guid.NewGuid(),
            Name = "Cincinnati Bengals",
            OwnerName = "Michael Brown",
            Location = new Location
            {
                Id = Guid.NewGuid(),
                City = "Cincinnati",
                State = "Ohio"
            },
            Mascot = "Who Dey",
            Staff = new Staff
            {
                Id = Guid.NewGuid(),
                HeadCoach = "Zac Taylor",
                OffensiveCoordinator = "Brian Callahan",
                DefensiveCoordinator = "Lou Anarumo",
                SpecialTeamsCoordinator = "Darrin Simmons"
            },
            Stadium = new Stadium
            {
                Id = Guid.NewGuid(),
                MaxCapacity = 65515,
            },
            TeamStats = new List<TeamStats>
            {
                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2022,
                    Wins = 12,
                    Losses = 4
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2021,
                    Wins = 10,
                    Losses = 7
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2020,
                    Wins = 4,
                    Losses = 11
                }
            }
        };
        modelBuilder.Entity<Team>().HasData(bengals);

        var saints = new Team
        {
            Id = Guid.NewGuid(),
            Name = "New Orleans Saints",
            OwnerName = "Gayle Benson",
            Location = new Location
            {
                Id = Guid.NewGuid(),
                City = "New Orleans",
                State = "Louisiana"
            },
            Mascot = "Sir Saint",
            Staff = new Staff
            {
                Id = Guid.NewGuid(),
                HeadCoach = "Dennis Allen",
                OffensiveCoordinator = "Pete Carmichael Jr.",
                DefensiveCoordinator = "Joe Woods",
                SpecialTeamsCoordinator = "Darren Rizzi"
            },
            Stadium = new Stadium
            {
                Id = Guid.NewGuid(),
                MaxCapacity = 76468,
            },
            TeamStats = new List<TeamStats>
            {
                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2022,
                    Wins = 7,
                    Losses = 10
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2021,
                    Wins = 9,
                    Losses = 8
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2020,
                    Wins = 12,
                    Losses = 4
                }
            }
        };
        modelBuilder.Entity<Team>().HasData(saints);

        var patriots = new Team
        {
            Id = Guid.NewGuid(),
            Name = "New England Patriots",
            OwnerName = "Robert Kraft",
            Location = new Location
            {
                Id = Guid.NewGuid(),
                City = "Foxborough",
                State = "Massachusetts"
            },
            Mascot = "Pat Patriot",
            Staff = new Staff
            {
                Id = Guid.NewGuid(),
                HeadCoach = "Bill Belichick",
                OffensiveCoordinator = "Bill O'Brien",
                DefensiveCoordinator = "Jerod Mayo",
                SpecialTeamsCoordinator = "Cameron Achord"
            },
            Stadium = new Stadium
            {
                Id = Guid.NewGuid(),
                MaxCapacity = 64628,
            },
            TeamStats = new List<TeamStats>
            {
                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2022,
                    Wins = 8,
                    Losses = 9
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2021,
                    Wins = 10,
                    Losses = 7
                },

                new TeamStats
                {
                    Id = Guid.NewGuid(),
                    Season = 2020,
                    Wins = 7,
                    Losses = 9
                }
            }
        };
        modelBuilder.Entity<Team>().HasData(patriots);
    }
}
