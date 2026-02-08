using MyApp.Models;

namespace MyApp.Repositories;

public interface IFriendRepository
{
    Task<IReadOnlyList<FriendModel>> GetAllAsync(CancellationToken cancellationToken = default);
}
