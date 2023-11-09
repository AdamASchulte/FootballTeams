﻿namespace FootballTeams.Entities;

public class Stadium
{
    public Guid Id { get; set; } = Guid.Empty;
    public int MaxCapacity { get; set; }
    public Team Team { get; set; }
}
