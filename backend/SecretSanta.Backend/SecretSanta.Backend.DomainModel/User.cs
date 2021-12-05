﻿namespace SecretSanta.Backend.DomainModel;

public class User : Entity
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public ICollection<BoxesUsers>? BoxesUsers { get; set; }
}