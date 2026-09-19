using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface ILessonProgressRepository : IGenericRepository<LessonProgress>
{
    Task<LessonProgress?> GetByUserAndLessonAsync(Guid userId, Guid lessonId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LessonProgress>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>This user's progress rows for one path - the numerator in "8 / 10 lessons".</summary>
    Task<IReadOnlyList<LessonProgress>> GetByUserAndLearningPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);

    Task<int> CountCompletedByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<int> CountCompletedInLearningPathAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);

    Task<int> CountCompletedInModuleAsync(Guid userId, Guid moduleId, CancellationToken cancellationToken = default);

    /// <summary>Distinct dates this user completed a lesson, newest first - the
    /// raw data for the learning-streak calculation.</summary>
    Task<IReadOnlyList<DateTime>> GetCompletionDatesByUserAsync(Guid userId, CancellationToken cancellationToken = default);
}
