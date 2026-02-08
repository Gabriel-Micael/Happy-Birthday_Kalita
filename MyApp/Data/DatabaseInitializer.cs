using Microsoft.EntityFrameworkCore;

namespace MyApp.Data;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();

        if (await context.Friends.AnyAsync())
        {
            return;
        }

        await context.Friends.AddRangeAsync(FriendSeedData.Create());
        await context.SaveChangesAsync();
    }
}
