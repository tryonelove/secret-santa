using Microsoft.EntityFrameworkCore;
using SecretSanta.Backend.DomainModel;

namespace SecretSanta.Backend.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Box> Boxes { get; set; }

    public DbSet<BoxesUsers> BoxesUsers { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}