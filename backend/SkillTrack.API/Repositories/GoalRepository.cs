using SkillTrack.API.Data;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class GoalRepository : GenericRepository<Goal>, IGoalRepository
{
    public GoalRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Goal>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<Goal?> GetByIdForUserAsync(Guid id, Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Goal>> GetByUserAndStatusAsync(Guid userId, GoalStatus status, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<Goal>> GetByUserAndLearningPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
