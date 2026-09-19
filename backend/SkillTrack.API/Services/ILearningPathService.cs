using SkillTrack.API.DTOs;
using SkillTrack.API.Enums;

namespace SkillTrack.API.Services;

public interface ILearningPathService
{
    /// <summary>Full details page - path + ordered modules (spec section 6/27).</summary>
    Task<LearningPathDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResult<LearningPathDto>> SearchAsync(
        string? searchTerm,
        Guid? skillId,
        DifficultyLevel? difficulty,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<LearningPathDto> CreateAsync(CreateLearningPathRequestDto request, CancellationToken cancellationToken = default);

    Task<LearningPathDto> UpdateAsync(Guid id, UpdateLearningPathRequestDto request, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LearningPathDto>> GetMostPopularAsync(int count, CancellationToken cancellationToken = default);

    /// <summary>Enrolls a user in a path - creates their UserLearningPath row (spec
    /// section 4.1 "Enroll in learning paths").</summary>
    Task EnrollUserAsync(Guid userId, Guid learningPathId, CancellationToken cancellationToken = default);
}
