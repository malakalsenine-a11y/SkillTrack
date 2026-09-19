using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface ILessonRepository : IGenericRepository<Lesson>
{
    Task<IReadOnlyList<Lesson>> GetByModuleIdAsync(Guid moduleId, CancellationToken cancellationToken = default);

    Task<Lesson?> GetByIdWithResourcesAsync(Guid id, CancellationToken cancellationToken = default);

    Task<int> GetNextOrderIndexAsync(Guid moduleId, CancellationToken cancellationToken = default);

    /// <summary>Total lessons in a path - the denominator in "8 / 10 lessons completed".</summary>
    Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);

    /// <summary>All lesson ids in a path, ordered - used to work out the "next lesson" recommendation.</summary>
    Task<IReadOnlyList<Lesson>> GetOrderedByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);
}
