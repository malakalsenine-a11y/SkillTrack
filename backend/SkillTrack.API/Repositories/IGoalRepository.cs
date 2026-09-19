using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IGoalRepository : IGenericRepository<Goal>
{
    Task<IReadOnlyList<Goal>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Ownership-safe fetch - returns null if the goal doesn't belong to
    /// this user, so a learner can never read/modify someone else's goal.</summary>
    Task<Goal?> GetByIdForUserAsync(Guid id, Guid userId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Goal>> GetByUserAndStatusAsync(Guid userId, GoalStatus status, CancellationToken cancellationToken = default);

    Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Goals linked to a learning path - so completing a path can auto-update its goal.</summary>
    Task<IReadOnlyList<Goal>> GetByUserAndLearningPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);
}
