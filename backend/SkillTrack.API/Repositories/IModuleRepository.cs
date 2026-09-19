using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface IModuleRepository : IGenericRepository<Module>
{
    Task<IReadOnlyList<Module>> GetByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);

    /// <summary>Module + its lessons, quizzes and assignments.</summary>
    Task<Module?> GetByIdWithContentAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Next OrderIndex to assign when an admin appends a new module.</summary>
    Task<int> GetNextOrderIndexAsync(Guid learningPathId, CancellationToken cancellationToken = default);

    Task<int> CountByLearningPathIdAsync(Guid learningPathId, CancellationToken cancellationToken = default);
}
