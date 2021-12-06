namespace SecretSanta.Backend.Foundation.Authentication.Models;

public class UserDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    // public ICollection<BoxesUsers> BoxesUsers { get; set; }
}