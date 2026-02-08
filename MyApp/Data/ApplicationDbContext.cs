using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<FriendModel> Friends => Set<FriendModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FriendModel>(entity =>
        {
            entity.ToTable("friends");
            entity.Property(friend => friend.Name).IsRequired();
            entity.Property(friend => friend.Description).IsRequired();
            entity.Property(friend => friend.ImagePath).IsRequired();
        });
    }
}
