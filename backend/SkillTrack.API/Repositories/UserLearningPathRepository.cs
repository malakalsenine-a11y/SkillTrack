using SkillTrack.API.Data;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public class UserLearningPathRepository : GenericRepository<UserLearningPath>, IUserLearningPathRepository
{
    public UserLearningPathRepository(SkillTrackDbContext context) : base(context)
    {
    }

    public Task<UserLearningPath?> GetByUserAndPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<UserLearningPath>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<IReadOnlyList<UserLearningPath>> GetActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<bool> IsEnrolledAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<int> CountEnrollmentsByPathAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<double> GetCompletionRateAsync(Guid learningPathId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
