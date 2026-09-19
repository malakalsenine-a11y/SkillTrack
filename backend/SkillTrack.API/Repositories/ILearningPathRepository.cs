using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;
using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories;

public interface ILearningPathRepository : IGenericRepository<LearningPath>
{
    /// <summary>Path + its modules only (ordered by OrderIndex).</summary>
    Task<LearningPath?> GetByIdWithModulesAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Full tree: modules -> lessons, quizzes, assignments. Used by the
    /// learning-path details page and by progress calculation.</summary>
    Task<LearningPath?> GetFullPathAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResult<LearningPath>> SearchAsync(
        string? searchTerm,
        Guid? skillId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LearningPath>> GetBySkillIdAsync(Guid skillId, CancellationToken cancellationToken = default);

    /// <summary>Most-enrolled paths, for the admin dashboard.</summary>
    Task<IReadOnlyList<LearningPath>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default);
}
