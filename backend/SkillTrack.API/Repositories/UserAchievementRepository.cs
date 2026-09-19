using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class UserAchievementRepository : GenericRepository<UserAchievement>, IUserAchievementRepository
{
    public UserAchievementRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<UserAchievement>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> HasAchievementAsync(Guid userId, Guid achievementId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
