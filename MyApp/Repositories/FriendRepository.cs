using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Repositories;

public class FriendRepository : IFriendRepository
{
    private readonly ApplicationDbContext _context;

    public FriendRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<FriendModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Friends
            .AsNoTracking()
            .OrderBy(friend => friend.Id)
            .ToListAsync(cancellationToken);
    }
}
