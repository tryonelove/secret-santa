namespace SecretSanta.Backend.DomainModel;

public class UserBox : Entity
{
    public int UserId { get; set; }

    public int BoxId { get; set; }

    public int? GiftToUserId { get; set; }

    public string Preferences { get; set; }

    public bool IsGifted { get; set; }

    public double? MaxGiftCost { get; set; }

    public User User { get; set; }

    public Box Box { get; set; }

    public User GiftToUser { get; set; }
}