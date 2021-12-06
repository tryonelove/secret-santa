using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretSanta.Backend.DomainModel;

namespace SecretSanta.Backend.DataAccess.Configurations;

public class BoxesUsersConfiguration : IEntityTypeConfiguration<UserBox>
{
    public void Configure(EntityTypeBuilder<UserBox> builder)
    {
        builder.HasKey(bu => new { bu.UserId, bu.BoxId });

        builder.HasOne(bu => bu.User)
            .WithMany(u => u.UserBoxes)
            .HasForeignKey(bu => bu.UserId);

        builder.HasOne(bu => bu.Box)
            .WithMany(b => b.UserBoxes)
            .HasForeignKey(bu => bu.BoxId);
    }
}