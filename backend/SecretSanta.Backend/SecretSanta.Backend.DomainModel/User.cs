using Microsoft.AspNetCore.Identity;

namespace SecretSanta.Backend.DomainModel;

public class User : IdentityUser<int>
{
    public string Name { get; set; }

    public ICollection<UserBox> UserBoxes { get; set; }
}