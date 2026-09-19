using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IUserAchievementRepository : IGenericRepository<UserAchievement>
{
    /// <summary>User's earned achievements, including the Achievement details.</summary>
    Task<IReadOnlyList<UserAchievement>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Guard against awarding the same achievement twice.</summary>
    Task<bool> HasAchievementAsync(Guid userId, Guid achievementId, CancellationToken cancellationToken = default);

    Task<int> CountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}
