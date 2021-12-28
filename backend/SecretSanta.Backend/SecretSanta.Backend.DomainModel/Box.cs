namespace SecretSanta.Backend.DomainModel;

public class Box : Entity
{
    public string Title { get; set; }

    public string Url { get; set; }

    public BoxStatus BoxStatus { get; set; }

    public ICollection<UserBox> UserBoxes { get; set; }
}