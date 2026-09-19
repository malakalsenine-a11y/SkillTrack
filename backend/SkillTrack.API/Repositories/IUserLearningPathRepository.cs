using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IUserLearningPathRepository : IGenericRepository<UserLearningPath>
{
    Task<UserLearningPath?> GetByUserAndPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);

    /// <summary>All enrollments for a user, including LearningPath details.</summary>
    Task<IReadOnlyList<UserLearningPath>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>In-progress enrollments only - the "Active Learning Paths: 3" dashboard stat.</summary>
    Task<IReadOnlyList<UserLearningPath>> GetActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<bool> IsEnrolledAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);

    Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<int> CountEnrollmentsByPathAsync(Guid learningPathId, CancellationToken cancellationToken = default);

    /// <summary>Share of enrollments that reached Completed - admin "completion rate" stat.</summary>
    Task<double> GetCompletionRateAsync(Guid learningPathId, CancellationToken cancellationToken = default);
}
